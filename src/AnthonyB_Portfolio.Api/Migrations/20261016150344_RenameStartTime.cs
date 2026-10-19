using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnthonyB_Portfolio.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameStartTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Experiences",
                newName: "StartDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Experiences",
                newName: "StartTime");
        }
    }
}
