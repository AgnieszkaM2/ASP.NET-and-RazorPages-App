using Microsoft.EntityFrameworkCore.Migrations;

namespace KsiazkaKucharska.Migrations
{
    public partial class AddRecipeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Czas = table.Column<string>(nullable: true),
                    Porcja = table.Column<string>(nullable: true),
                    Skladniki = table.Column<string>(nullable: true),
                    Instrukcje = table.Column<string>(nullable: true),
                    Zdjecie = table.Column<string>(nullable: true),
                    Rodzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
