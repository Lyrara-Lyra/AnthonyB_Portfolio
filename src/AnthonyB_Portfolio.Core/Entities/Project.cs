namespace AnthonyB_Portfolio.Core.Entities;

public class Project
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? Url { get; set; }
    public int DisplayOrder { get; set; }

    public List<Skill> Skills { get; set; } = [];
}