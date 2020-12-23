using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateCisStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addition",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Appreciation",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Carear",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "City",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Colleage",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "CisStudents");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CisStudents");

            migrationBuilder.RenameColumn(
                name: "kind",
                table: "CisStudents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "University",
                table: "CisStudents",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Programing_Language",
                table: "CisStudents",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CisStudents",
                newName: "kind");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "CisStudents",
                newName: "University");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CisStudents",
                newName: "Programing_Language");

            migrationBuilder.AddColumn<string>(
                name: "Addition",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Appreciation",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Carear",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colleage",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "CisStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CisStudents",
                nullable: true);
        }
    }
}
