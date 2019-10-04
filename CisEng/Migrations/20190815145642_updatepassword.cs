using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class updatepassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "CisStudent",
                newName: "studentpassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "studentpassword",
                table: "CisStudent",
                newName: "password");
        }
    }
}
