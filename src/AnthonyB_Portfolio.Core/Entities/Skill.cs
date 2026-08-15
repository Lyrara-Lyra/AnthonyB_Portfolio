namespace AnthonyB_Portfolio.Core.Entities;

public class Skill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
    public int DisplayOrder { get; set; }

    public Category Category { get; set; } = null!;
    public List<Project> Projects { get; set; }
    public List<Experience> Experiences { get; set; }
}