using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class updatepost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Posts",
                nullable: true);
        }
    }
}
