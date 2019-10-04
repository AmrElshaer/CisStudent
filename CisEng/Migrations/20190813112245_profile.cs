using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CisEng.Migrations
{
    public partial class profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country = table.Column<string>(nullable: true),
                    Colleage = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Program_Language = table.Column<string>(nullable: true),
                    Carear = table.Column<string>(nullable: true),
                    Appreciation = table.Column<string>(nullable: true),
                    Company_youWork = table.Column<string>(nullable: true),
                    Addition = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
