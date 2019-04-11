using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerLeague.Migrations
{
    public partial class UpdateProyect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayers",
                table: "FootballPlayers");

            migrationBuilder.RenameTable(
                name: "FootballPlayers",
                newName: "FootballPlayer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayer",
                table: "FootballPlayer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballTeams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "FootballTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayer",
                table: "FootballPlayer");

            migrationBuilder.RenameTable(
                name: "FootballPlayer",
                newName: "FootballPlayers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayers",
                table: "FootballPlayers",
                column: "Id");
        }
    }
}
