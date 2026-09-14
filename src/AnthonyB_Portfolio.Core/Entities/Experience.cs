namespace AnthonyB_Portfolio.Core.Entities;

public class Experience
{
    public int Id { get; set; }
    public ExperienceType Type { get; set; }
    public required string Title { get; set; }
    public required string Organization { get; set; }
    public string? Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndDate { get; set; }
    public required string Summary { get; set; }
    public bool IsVisible { get; set; } = false;

    public List<Responsibility> Responsibilities { get; set; } = [];
    public List<ExperienceSkill> Skills { get; set; } = [];
}