using Microsoft.EntityFrameworkCore;
using Cantask.Models;

public class AppDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}