using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonationApplication.Migrations
{
    public partial class BDAMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klinika",
                columns: table => new
                {
                    KlinikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klinika", x => x.KlinikaId);
                });

            migrationBuilder.CreateTable(
                name: "KomponenteKrvi",
                columns: table => new
                {
                    KomponenteKrviId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Eritrociti = table.Column<double>(nullable: false),
                    Trombociti = table.Column<double>(nullable: false),
                    Leukociti = table.Column<double>(nullable: false),
                    KrvnaPlazma = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomponenteKrvi", x => x.KomponenteKrviId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    sifra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "KrvnaGrupa",
                columns: table => new
                {
                    KrvnaGrupaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrvnaGrupa", x => x.KrvnaGrupaId);
                });

            migrationBuilder.CreateTable(
                name: "Zavod",
                columns: table => new
                {
                    ZavodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zavod", x => x.ZavodId);
                });

            migrationBuilder.CreateTable(
                name: "LaboratorijskiNalaz",
                columns: table => new
                {
                    LaboratorijskiNalazId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KomponenteKrviId = table.Column<int>(nullable: true),
                    Hemoglobin = table.Column<double>(nullable: false),
                    Glukoza = table.Column<double>(nullable: false),
                    Holesterol = table.Column<double>(nullable: false),
                    Trigliceridi = table.Column<double>(nullable: false),
                    Zeljezo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratorijskiNalaz", x => x.LaboratorijskiNalazId);
                    table.ForeignKey(
                        name: "FK_LaboratorijskiNalaz_KomponenteKrvi_KomponenteKrviId",
                        column: x => x.KomponenteKrviId,
                        principalTable: "KomponenteKrvi",
                        principalColumn: "KomponenteKrviId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    DonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true),
                    KrvnaGrupaId = table.Column<int>(nullable: true),
                    BrojMobilnogTelefona = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    ZavodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.DonorId);
                    table.ForeignKey(
                        name: "FK_Donor_KrvnaGrupa_KrvnaGrupaId",
                        column: x => x.KrvnaGrupaId,
                        principalTable: "KrvnaGrupa",
                        principalColumn: "KrvnaGrupaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donor_Zavod_ZavodId",
                        column: x => x.ZavodId,
                        principalTable: "Zavod",
                        principalColumn: "ZavodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    ZahtjevId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Odobren = table.Column<bool>(nullable: false),
                    KolicinaKrvi = table.Column<double>(nullable: false),
                    KolicineKopmonentiKomponenteKrviId = table.Column<int>(nullable: true),
                    KrvnaGrupaId = table.Column<int>(nullable: true),
                    KlinikaId = table.Column<int>(nullable: true),
                    ZavodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.ZahtjevId);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Klinika_KlinikaId",
                        column: x => x.KlinikaId,
                        principalTable: "Klinika",
                        principalColumn: "KlinikaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_KomponenteKrvi_KolicineKopmonentiKomponenteKrviId",
                        column: x => x.KolicineKopmonentiKomponenteKrviId,
                        principalTable: "KomponenteKrvi",
                        principalColumn: "KomponenteKrviId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_KrvnaGrupa_KrvnaGrupaId",
                        column: x => x.KrvnaGrupaId,
                        principalTable: "KrvnaGrupa",
                        principalColumn: "KrvnaGrupaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Zavod_ZavodId",
                        column: x => x.ZavodId,
                        principalTable: "Zavod",
                        principalColumn: "ZavodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zalihe",
                columns: table => new
                {
                    ZaliheId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Eritrociti = table.Column<double>(nullable: false),
                    Trombociti = table.Column<double>(nullable: false),
                    Leukociti = table.Column<double>(nullable: false),
                    KrvnaPlazma = table.Column<double>(nullable: false),
                    Krv = table.Column<double>(nullable: false),
                    KrvnaGrupaId = table.Column<int>(nullable: true),
                    ZavodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalihe", x => x.ZaliheId);
                    table.ForeignKey(
                        name: "FK_Zalihe_KrvnaGrupa_KrvnaGrupaId",
                        column: x => x.KrvnaGrupaId,
                        principalTable: "KrvnaGrupa",
                        principalColumn: "KrvnaGrupaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zalihe_Zavod_ZavodId",
                        column: x => x.ZavodId,
                        principalTable: "Zavod",
                        principalColumn: "ZavodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donacija",
                columns: table => new
                {
                    DonacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumDonacije = table.Column<DateTime>(nullable: false),
                    DonorId = table.Column<int>(nullable: true),
                    DoniraneKolicineKomponenteKrviId = table.Column<int>(nullable: true),
                    DoniranaKolicinaKrvi = table.Column<double>(nullable: false),
                    ZavodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donacija", x => x.DonacijaId);
                    table.ForeignKey(
                        name: "FK_Donacija_KomponenteKrvi_DoniraneKolicineKomponenteKrviId",
                        column: x => x.DoniraneKolicineKomponenteKrviId,
                        principalTable: "KomponenteKrvi",
                        principalColumn: "KomponenteKrviId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_Zavod_ZavodId",
                        column: x => x.ZavodId,
                        principalTable: "Zavod",
                        principalColumn: "ZavodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pregled",
                columns: table => new
                {
                    PregledId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPregleda = table.Column<DateTime>(nullable: false),
                    DetaljiPregleda = table.Column<string>(nullable: true),
                    UspjesanPregled = table.Column<bool>(nullable: false),
                    LabNalazIdLaboratorijskiNalazId = table.Column<int>(nullable: true),
                    DonorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregled", x => x.PregledId);
                    table.ForeignKey(
                        name: "FK_Pregled_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pregled_LaboratorijskiNalaz_LabNalazIdLaboratorijskiNalazId",
                        column: x => x.LabNalazIdLaboratorijskiNalazId,
                        principalTable: "LaboratorijskiNalaz",
                        principalColumn: "LaboratorijskiNalazId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_DoniraneKolicineKomponenteKrviId",
                table: "Donacija",
                column: "DoniraneKolicineKomponenteKrviId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_DonorId",
                table: "Donacija",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_ZavodId",
                table: "Donacija",
                column: "ZavodId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_KrvnaGrupaId",
                table: "Donor",
                column: "KrvnaGrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_ZavodId",
                table: "Donor",
                column: "ZavodId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratorijskiNalaz_KomponenteKrviId",
                table: "LaboratorijskiNalaz",
                column: "KomponenteKrviId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_DonorId",
                table: "Pregled",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_LabNalazIdLaboratorijskiNalazId",
                table: "Pregled",
                column: "LabNalazIdLaboratorijskiNalazId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KlinikaId",
                table: "Zahtjev",
                column: "KlinikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KolicineKopmonentiKomponenteKrviId",
                table: "Zahtjev",
                column: "KolicineKopmonentiKomponenteKrviId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KrvnaGrupaId",
                table: "Zahtjev",
                column: "KrvnaGrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_ZavodId",
                table: "Zahtjev",
                column: "ZavodId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalihe_KrvnaGrupaId",
                table: "Zalihe",
                column: "KrvnaGrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalihe_ZavodId",
                table: "Zalihe",
                column: "ZavodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donacija");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Pregled");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "Zalihe");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "LaboratorijskiNalaz");

            migrationBuilder.DropTable(
                name: "Klinika");

            migrationBuilder.DropTable(
                name: "KrvnaGrupa");

            migrationBuilder.DropTable(
                name: "Zavod");

            migrationBuilder.DropTable(
                name: "KomponenteKrvi");
        }
    }
}
