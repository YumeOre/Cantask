namespace Cantask.Models;

public class Node
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Type { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastInteraction { get; set; } = DateTime.UtcNow;
    public NodeState State { get; set; } = NodeState.Active;
    public int UsageFrequency { get; set; } = 0;
    public double InfluenceLevel { get; set; } = 0.0;
}

public enum NodeState
{
    Active,
    Latent,
    Archived
}