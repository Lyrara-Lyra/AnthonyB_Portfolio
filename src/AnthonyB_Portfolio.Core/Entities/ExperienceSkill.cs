using System.Text.Json.Serialization;

namespace AnthonyB_Portfolio.Core.Entities;

public class ExperienceSkill
{
    public int ExperienceId { get; set; }
    [JsonIgnore]
    public Experience Experience { get; set; } = null!;

    public int SkillId { get; set; }
    public Skill Skill { get; set; } = null!;

    public int DisplayOrder { get; set; }
    public bool IsHighlighted { get; set; } = false;
}
