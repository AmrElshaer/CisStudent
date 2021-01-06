using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updatePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Technology",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Technology",
                table: "Posts",
                nullable: true);
        }
    }
}
