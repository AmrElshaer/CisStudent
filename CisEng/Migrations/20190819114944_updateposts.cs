using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class updateposts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prop",
                table: "Posts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "CisStudentId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PostPrivte",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Postcontaint",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Technology",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CisStudentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostPrivte",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Postcontaint",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Technology",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "prop");
        }
    }
}
