using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHeroProject.Data.Migrations
{
    public partial class EnterYourMigrationNameHere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "superHeroes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AlterEgo = table.Column<string>(nullable: true),
                    PrimaryAbility = table.Column<string>(nullable: true),
                    SecondaryAbility = table.Column<string>(nullable: true),
                    Catchphrase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_superHeroes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "superHeroes");
        }
    }
}
