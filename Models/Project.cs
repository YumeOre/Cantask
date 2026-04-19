namespace Cantask.Models;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int ActivityLevel { get; set; } = 0;
    public int GrowthRate { get; set; } = 0;
}