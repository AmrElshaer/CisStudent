using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class updateresponsetocomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idof",
                table: "ResponsetoComment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idof",
                table: "ResponsetoComment");
        }
    }
}
