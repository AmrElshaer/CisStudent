using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class resToresSelfJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "ResponseToResponses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToResponses_ResponseId",
                table: "ResponseToResponses",
                column: "ResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseToResponses_ResponseToResponses_ResponseId",
                table: "ResponseToResponses",
                column: "ResponseId",
                principalTable: "ResponseToResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseToResponses_ResponseToResponses_ResponseId",
                table: "ResponseToResponses");

            migrationBuilder.DropIndex(
                name: "IX_ResponseToResponses_ResponseId",
                table: "ResponseToResponses");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "ResponseToResponses");
        }
    }
}
