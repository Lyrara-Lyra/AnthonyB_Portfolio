using System.Text.Json.Serialization;

namespace AnthonyB_Portfolio.Core.Entities;

public class ProjectDetail
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public required string Description { get; set; }
    public int DisplayOrder { get; set; }

    [JsonIgnore]
    public Project Project { get; set; } = null!;
}