using Cantask.Models;

namespace Cantask.Data;

public static class DatabaseInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Nodes.Any())
        {
            var node1 = new Node { Type = NodeType.Concept, Content = "Primer nodo" };
            var node2 = new Node { Type = NodeType.Task, Content = "Segundo nodo" };
            context.Nodes.Add(node1);
            context.Nodes.Add(node2);

            var relationship = new Relationship
            {
                SourceNodeId = node1.Id,
                TargetNodeId = node2.Id,
                Type = RelationshipType.Reference
            };

            context.Relationships.Add(relationship);
            context.SaveChanges();
        }
    }
}