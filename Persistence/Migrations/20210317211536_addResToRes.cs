using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addResToRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseToResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ResponseToCommentId = table.Column<int>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseToResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseToResponses_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponseToResponses_ResponseToComments_ResponseToCommentId",
                        column: x => x.ResponseToCommentId,
                        principalTable: "ResponseToComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToResponses_CisStudentId",
                table: "ResponseToResponses",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToResponses_ResponseToCommentId",
                table: "ResponseToResponses",
                column: "ResponseToCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseToResponses");
        }
    }
}
