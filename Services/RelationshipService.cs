using Cantask.Models;
public class RelationshipService
{
    private readonly AppDbContext _context;

    public RelationshipService(AppDbContext context)
    {
        _context = context;
    }

    public List<Relationship> GetAllRelationships()
    {
        return _context.Relationships.ToList();
    }

    public void AddRelationship(Relationship relationship)
    {
        _context.Relationships.Add(relationship);
        _context.SaveChanges();
    }

    public void ConnectNodes(Guid sourceId, Guid targetId, RelationshipType type)
{
    var relationship = new Relationship
    {
        SourceNodeId = sourceId,
        TargetNodeId = targetId,
        Type = type
    };

    _context.Relationships.Add(relationship);
    _context.SaveChanges();
}
}