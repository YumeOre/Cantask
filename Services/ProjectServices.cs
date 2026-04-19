using Cantask.Models;
using Microsoft.EntityFrameworkCore;

namespace Cantask.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Obtener todos los proyectos
        public List<Project> GetAllProjects()
        {
            return _context.Projects
                .Include(p => p.Nodes)
                .OrderByDescending(p => p.Vitality)
                .ToList();
        }

        // 🔹 Crear proyecto
        public Project CreateProject(string name)
        {
            var project = new Project
            {
                Name = name,
                Vitality = 0,
                ActivityLevel = 0,
                GrowthRate = 0
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            return project;
        }

        //  AQUÍ VA TU LÓGICA IMPORTANTE
        public void UpdateProjectState(Guid projectId)
        {
            var project = _context.Projects
                .Include(p => p.Nodes)
                .ThenInclude(n => n.OutgoingRelations)
                .Include(p => p.Nodes)
                .ThenInclude(n => n.IncomingRelations)
                .FirstOrDefault(p => p.Id == projectId);

            if (project == null) return;

            if (project.Nodes.Count == 0)
            {
                project.Vitality = 0;
                project.ActivityLevel = 0;
                project.GrowthRate = 0;
                _context.SaveChanges();
                return;
            }

            //  Vitalidad = promedio de influencia
            project.Vitality = project.Nodes.Sum(n =>
            {
                var connectionScore =
                    n.OutgoingRelations.Count +
                    n.IncomingRelations.Count;

                return
                    (n.UsageFrequency * 0.3) +
                    (n.InfluenceLevel * 0.5) +
                    (connectionScore * 0.2);
            });

            //  Actividad = uso total
            project.ActivityLevel = project.Nodes.Sum(n => n.UsageFrequency);

            // Crecimiento simple (puedes mejorar luego)
            project.GrowthRate =
                project.Nodes.Count(n => n.State == NodeState.Active) * 1.0;

            _context.SaveChanges();
        }

        // 🔹 Obtener un proyecto con nodos
        public Project GetProject(Guid id)
        {
            return _context.Projects
                .Include(p => p.Nodes)
                .FirstOrDefault(p => p.Id == id);
        }

        // 🔹 Eliminar proyecto
        public void DeleteProject(Guid id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
        public void RecalculateAllProjects()
    {
            var projects = _context.Projects
                .Include(p => p.Nodes)
                .ToList();

            foreach (var project in projects)
            {
                if (project.Nodes.Count == 0)
                {
                    project.Vitality = 0;
                    project.ActivityLevel = 0;
                    project.GrowthRate = 0;
                }
                else
                {
                    project.Vitality = project.Nodes.Average(n => n.InfluenceLevel);
                    project.ActivityLevel = project.Nodes.Sum(n => n.UsageFrequency);
                    project.GrowthRate = project.Nodes.Count(n => n.State == NodeState.Active);
                }
            }

            _context.SaveChanges();
        }
    }
}