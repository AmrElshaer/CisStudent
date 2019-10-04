using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class updateprofille : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Profile",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "kind",
                table: "Profile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kind",
                table: "Profile");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Profile",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
