namespace Cantask.Models;

public class Node
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public NodeType Type { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastInteraction { get; set; } = DateTime.UtcNow;
    public NodeState State { get; set; } = NodeState.Active;
    public int UsageFrequency { get; set; } = 0;
    public double InfluenceLevel { get; set; } = 0.0;
    
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }

    public List<Relationship> OutgoingRelations { get; set; } = new();
    public List<Relationship> IncomingRelations { get; set; } = new();
}

public enum NodeState
{
    Active,
    Latent,
    Archived
}

public enum NodeType
{
    Concept,
    Task,
    Idea,
    Resource,
    Question
}