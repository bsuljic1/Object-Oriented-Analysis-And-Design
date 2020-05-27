using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBANK.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    Lozinka = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kredit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsplaceniIznos = table.Column<float>(nullable: false),
                    PocetakOtpate = table.Column<DateTime>(nullable: false),
                    StatusKredita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kredit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Novost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijemeDodavanja = table.Column<DateTime>(nullable: false),
                    Naslov = table.Column<string>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: false),
                    prikazana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanjeRacuna = table.Column<float>(nullable: false),
                    vrstaRacuna = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjevZaKredit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PocetakOtpate = table.Column<DateTime>(nullable: false),
                    NamjenaKredita = table.Column<string>(nullable: false),
                    MjesecniPrihodi = table.Column<float>(nullable: false),
                    ProsjecniTroskoviDomacinstva = table.Column<float>(nullable: false),
                    NazivRadnogMjesta = table.Column<string>(nullable: false),
                    NazivPoslodavca = table.Column<string>(nullable: false),
                    RadniStaz = table.Column<int>(nullable: false),
                    BrojNekretnina = table.Column<int>(nullable: false),
                    BrojNeplacenihDugova = table.Column<float>(nullable: false),
                    StatusKredita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaKredit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bankar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    Lozinka = table.Column<string>(nullable: false),
                    MjestoZaposlenjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bankar_Adresa_MjestoZaposlenjaId",
                        column: x => x.MjestoZaposlenjaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bankomat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankomat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bankomat_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filijala",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filijala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filijala_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    Lozinka = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false),
                    BrojLicneKarte = table.Column<string>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false),
                    Zanimanje = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijent_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transakcija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijeme = table.Column<DateTime>(nullable: false),
                    saRacunaId = table.Column<int>(nullable: false),
                    naRacunId = table.Column<int>(nullable: false),
                    Iznos = table.Column<float>(nullable: false),
                    VrstaTransakcije = table.Column<int>(nullable: false),
                    NacinTransakcije = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transakcija_Racun_naRacunId",
                        column: x => x.naRacunId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transakcija_Racun_saRacunaId",
                        column: x => x.saRacunaId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bankar_MjestoZaposlenjaId",
                table: "Bankar",
                column: "MjestoZaposlenjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bankomat_AdresaId",
                table: "Bankomat",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filijala_AdresaId",
                table: "Filijala",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_AdresaId",
                table: "Klijent",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_naRacunId",
                table: "Transakcija",
                column: "naRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_saRacunaId",
                table: "Transakcija",
                column: "saRacunaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Bankar");

            migrationBuilder.DropTable(
                name: "Bankomat");

            migrationBuilder.DropTable(
                name: "Filijala");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Kredit");

            migrationBuilder.DropTable(
                name: "Novost");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "ZahtjevZaKredit");

            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Racun");
        }
    }
}
