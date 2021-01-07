using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updateTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_CisStudents_CisStudentId",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "CisStudentId",
                table: "Trainings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_CisStudents_CisStudentId",
                table: "Trainings",
                column: "CisStudentId",
                principalTable: "CisStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_CisStudents_CisStudentId",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "CisStudentId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_CisStudents_CisStudentId",
                table: "Trainings",
                column: "CisStudentId",
                principalTable: "CisStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
