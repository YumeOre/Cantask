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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 🔗 Relación: nodo origen → relaciones salientes
        modelBuilder.Entity<Relationship>()
            .HasOne(r => r.SourceNode)
            .WithMany(n => n.OutgoingRelations)
            .HasForeignKey(r => r.SourceNodeId)
            .OnDelete(DeleteBehavior.Restrict);

        // 🔗 Relación: nodo destino → relaciones entrantes
        modelBuilder.Entity<Relationship>()
            .HasOne(r => r.TargetNode)
            .WithMany(n => n.IncomingRelations)
            .HasForeignKey(r => r.TargetNodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}