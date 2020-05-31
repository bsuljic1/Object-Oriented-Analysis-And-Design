using Microsoft.EntityFrameworkCore.Migrations;

namespace EBANK.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "Klijent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Klijent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Konverzija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iznos = table.Column<float>(nullable: false),
                    IzValute = table.Column<int>(nullable: false),
                    UValutu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konverzija", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konverzija");

            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "Klijent");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Klijent");
        }
    }
}
