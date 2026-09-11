using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnthonyB_Portfolio.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillOrderingAndVisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Projects",
                newName: "IsVisible");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "ProjectSkills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHighlighted",
                table: "ProjectSkills",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "ExperienceSkills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHighlighted",
                table: "ExperienceSkills",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Experiences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "ProjectSkills");

            migrationBuilder.DropColumn(
                name: "IsHighlighted",
                table: "ProjectSkills");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "ExperienceSkills");

            migrationBuilder.DropColumn(
                name: "IsHighlighted",
                table: "ExperienceSkills");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "IsVisible",
                table: "Projects",
                newName: "DisplayOrder");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Skills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
