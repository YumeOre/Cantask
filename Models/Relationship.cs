namespace Cantask.Models;

public class Relationship
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid SourceNodeId { get; set; }
    public Node SourceNode { get; set; }

    public Guid TargetNodeId { get; set; }
    public Node TargetNode { get; set; }

    public RelationshipType Type { get; set; }
}

public enum RelationshipType
{
    Reference,
    Cause,
    Extension,
    Contradiction,
    Inspiration
}