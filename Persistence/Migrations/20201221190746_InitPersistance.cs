using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitPersistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CisStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Colleage = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Programing_Language = table.Column<string>(nullable: true),
                    Carear = table.Column<string>(nullable: true),
                    Appreciation = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Addition = table.Column<string>(nullable: true),
                    kind = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CisStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsAccepte = table.Column<bool>(nullable: false),
                    CisStudentSendId = table.Column<int>(nullable: true),
                    CisStudentRecieveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_CisStudents_CisStudentRecieveId",
                        column: x => x.CisStudentRecieveId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follows_CisStudents_CisStudentSendId",
                        column: x => x.CisStudentSendId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Technology = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ContactUs = table.Column<string>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Technology = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CisStudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Colleage = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Programing_Language = table.Column<string>(nullable: true),
                    Carear = table.Column<string>(nullable: true),
                    Appreciation = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Addition = table.Column<string>(nullable: true),
                    kind = table.Column<string>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Technology = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    CreateDate = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<int>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplyTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    TrainingId = table.Column<int>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyTrainings_CisStudents_CisStudentId",
                        column: x => x.CisStudentId,
                        principalTable: "CisStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponseToComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CommentId = table.Column<int>(nullable: true),
                    CisStudentId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_CisStudentId",
                table: "ApplyJobs",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobId",
                table: "ApplyJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTrainings_CisStudentId",
                table: "ApplyTrainings",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTrainings_TrainingId",
                table: "ApplyTrainings",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CisStudentId",
                table: "Comments",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_CisStudentRecieveId",
                table: "Follows",
                column: "CisStudentRecieveId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_CisStudentSendId",
                table: "Follows",
                column: "CisStudentSendId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CisStudentId",
                table: "Jobs",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CisStudentId",
                table: "Posts",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CisStudentId",
                table: "Profiles",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToComments_CisStudentId",
                table: "ResponseToComments",
                column: "CisStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToComments_CommentId",
                table: "ResponseToComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CisStudentId",
                table: "Trainings",
                column: "CisStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobs");

            migrationBuilder.DropTable(
                name: "ApplyTrainings");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ResponseToComments");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "CisStudents");
        }
    }
}
