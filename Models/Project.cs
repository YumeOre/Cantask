namespace Cantask.Models;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    //  vida del proyecto
    public double Vitality { get; set; } = 0;

    //actividad general
    public int ActivityLevel { get; set; } = 0;

    //  crecimiento
    public double GrowthRate { get; set; } = 0;

    //  relación
    public List<Node> Nodes { get; set; } = new();

    public string GetVitalityState()
{
    if (Vitality <= 0) return "Muerto";
    if (Vitality < 5) return "Inerte";
    if (Vitality < 10) return "Indiferente";
    if (Vitality < 20) return "Inestable";
    if (Vitality < 40) return "Normal";
    if (Vitality < 70) return "Activo";
    if (Vitality < 100) return "Enérgico";
    if (Vitality < 150) return "Consistente";
    if (Vitality < 250) return "Expansivo";

    return "Trascendente";
}
}