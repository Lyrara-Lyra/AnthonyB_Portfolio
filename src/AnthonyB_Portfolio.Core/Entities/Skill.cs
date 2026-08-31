using System.Text.Json.Serialization;

namespace AnthonyB_Portfolio.Core.Entities;

public class Skill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
    public int DisplayOrder { get; set; }

    [JsonIgnore]
    public Category Category { get; set; } = null!;
    [JsonIgnore]
    public List<Project> Projects { get; set; } = [];
    [JsonIgnore]
    public List<Experience> Experiences { get; set; } = [];
}