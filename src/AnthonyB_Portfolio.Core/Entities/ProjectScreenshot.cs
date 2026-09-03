using System.Text.Json.Serialization;

namespace AnthonyB_Portfolio.Core.Entities;

public class ProjectScreenshot
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public required string Url { get; set; }
    public int DisplayOrder { get; set; }
    public string? Caption { get; set; }

    [JsonIgnore]
    public Project Project { get; set; } = null!;
}