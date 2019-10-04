using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class updatePostview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostPrivte",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PostPrivte",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
