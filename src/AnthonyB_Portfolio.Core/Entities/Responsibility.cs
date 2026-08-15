namespace AnthonyB_Portfolio.Core.Entities;

public class Responsibility
{
    public int Id { get; set; }
    public int ExperienceId { get; set; }
    public required string Description { get; set; }
    public int DisplayOrder { get; set; }

    public Experience Experience { get; set; } = null!;
}