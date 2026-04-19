using Cantask.Models;
using Microsoft.EntityFrameworkCore;

namespace Cantask.Services
{
    public class NodeService
    {
        private readonly AppDbContext _context;

        public NodeService(AppDbContext context)
        {
            _context = context;
        }

        public List<Node> GetAllNodes()
        {
            return _context.Nodes.ToList();
        }

        public Node CreateNode(NodeType type, string content, Guid projectId)
        {
            var now = DateTime.UtcNow;

            var node = new Node
            {
                Type = type,
                Content = content,
                ProjectId = projectId == Guid.Empty ? null : projectId,
                CreatedAt = now,
                LastInteraction = now,
                State = NodeState.Active,
                UsageFrequency = 1,
                InfluenceLevel = 0
            };

            _context.Nodes.Add(node);
            _context.SaveChanges();

            return node;
        }

        public Node GetNodeWithRelations(Guid id)
        {
            return _context.Nodes
                .Include(n => n.OutgoingRelations)
                    .ThenInclude(r => r.TargetNode)
                .Include(n => n.IncomingRelations)
                    .ThenInclude(r => r.SourceNode)
                .FirstOrDefault(n => n.Id == id);
        }

        public void DeleteNode(Guid id)
        {
            var node = _context.Nodes.Find(id);
            if (node != null)
            {
                _context.Nodes.Remove(node);
                _context.SaveChanges();
            }
        }

        // Legacy (usar con cuidado)
        public void AddNode(Node node)
        {
            _context.Nodes.Add(node);
            _context.SaveChanges();
        }
    }
}