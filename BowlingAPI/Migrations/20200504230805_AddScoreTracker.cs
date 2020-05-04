using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingAPI.Migrations
{
    public partial class AddScoreTracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "scoreAtFrame",
                table: "Frames",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scoreAtFrame",
                table: "Frames");
        }
    }
}
