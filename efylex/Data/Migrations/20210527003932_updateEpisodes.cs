using Microsoft.EntityFrameworkCore.Migrations;

namespace efylex.Data.Migrations
{
    public partial class updateEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EpisodeName",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpisodeName",
                table: "Episodes");
        }
    }
}
