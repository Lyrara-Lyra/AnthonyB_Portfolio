using System.Text.Json.Serialization;

namespace AnthonyB_Portfolio.Core.Entities;

public class ProjectSkill
{
    public int ProjectId { get; set; }
    [JsonIgnore]
    public Project Project { get; set; } = null!;

    public int SkillId { get; set; }
    public Skill Skill { get; set; } = null!;

    public int DisplayOrder { get; set; }
    public bool IsHighlighted { get; set; } = false;
}
