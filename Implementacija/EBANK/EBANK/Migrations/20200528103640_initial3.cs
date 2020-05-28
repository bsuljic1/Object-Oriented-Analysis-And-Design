using Microsoft.EntityFrameworkCore.Migrations;

namespace EBANK.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Spol",
                table: "Klijent",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spol",
                table: "Klijent");
        }
    }
}
