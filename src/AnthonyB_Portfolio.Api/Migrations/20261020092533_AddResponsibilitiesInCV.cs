using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnthonyB_Portfolio.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsibilitiesInCV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncludeInCV",
                table: "Responsibilities",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludeInCV",
                table: "Responsibilities");
        }
    }
}
