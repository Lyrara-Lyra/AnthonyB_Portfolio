using System.Text.Json.Serialization;

namespace AnthonyB_Portfolio.Core.Entities;

public class Responsibility
{
    public int Id { get; set; }
    public int ExperienceId { get; set; }
    public required string Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IncludeInCV { get; set; } = true;

    [JsonIgnore]
    public Experience Experience { get; set; } = null!;
}