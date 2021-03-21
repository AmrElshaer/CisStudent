using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemoveUnRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseToResponses");

            migrationBuilder.DropTable(
                name: "ResponseToComments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "ResponseToComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CisStudentId = table.Column<int>(nullable: true),
                    CommentId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseToComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseToComments_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponseToComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponseToResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CisStudentId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ResponseId = table.Column<int>(nullable: true),
                    ResponseToCommentId = table.Column<int>(nullable: true)
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
                        name: "FK_ResponseToResponses_ResponseToResponses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "ResponseToResponses",
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
                name: "IX_ResponseToComments_CisStudentId",
                table: "ResponseToComments",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToComments_CommentId",
                table: "ResponseToComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToResponses_CisStudentId",
                table: "ResponseToResponses",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToResponses_ResponseId",
                table: "ResponseToResponses",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToResponses_ResponseToCommentId",
                table: "ResponseToResponses",
                column: "ResponseToCommentId");
        }
    }
}
