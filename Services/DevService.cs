using Cantask.Models;

namespace Cantask.Services
{
    public class DevService
    {
        private readonly AppDbContext _context;

        public DevService(AppDbContext context)
        {
            _context = context;
        }

        public void ClearAllData()
        {
            //  orden importa por las FK
            _context.Relationships.RemoveRange(_context.Relationships);
            _context.Nodes.RemoveRange(_context.Nodes);
            _context.Projects.RemoveRange(_context.Projects);

            _context.SaveChanges();
        }

        
    }
}