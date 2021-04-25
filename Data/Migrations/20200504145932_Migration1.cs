using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turismul_In_Capitalele_Europene.Data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Numar_Intrebari",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numar_Raspunsuri",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nume",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenume",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Capitale",
                columns: table => new
                {
                    CapitalaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Tara = table.Column<string>(nullable: true),
                    Regiune = table.Column<string>(nullable: true),
                    Fondare_secol = table.Column<int>(nullable: false),
                    Populatie = table.Column<int>(nullable: false),
                    Suprafata_kmp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitale", x => x.CapitalaId);
                });

            migrationBuilder.CreateTable(
                name: "Intrebari",
                columns: table => new
                {
                    IntrebareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Continut = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intrebari", x => x.IntrebareId);
                    table.ForeignKey(
                        name: "FK_Intrebari_AspNetUsers_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nivele",
                columns: table => new
                {
                    NivelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Punctaj_min = table.Column<int>(nullable: false),
                    Punctaj_max = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivele", x => x.NivelId);
                });

            migrationBuilder.CreateTable(
                name: "Raspunsuri",
                columns: table => new
                {
                    RaspunsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntrebareId = table.Column<int>(nullable: false),
                    UtilizatorId = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Continut = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspunsuri", x => x.RaspunsId);
                    table.ForeignKey(
                        name: "FK_Raspunsuri_Intrebari_IntrebareId",
                        column: x => x.IntrebareId,
                        principalTable: "Intrebari",
                        principalColumn: "IntrebareId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Raspunsuri_AspNetUsers_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turisti",
                columns: table => new
                {
                    TuristId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<string>(nullable: true),
                    NivelId = table.Column<int>(nullable: false),
                    Locatii_Vizitate = table.Column<int>(nullable: false),
                    Scor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turisti", x => x.TuristId);
                    table.ForeignKey(
                        name: "FK_Turisti_Nivele_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Nivele",
                        principalColumn: "NivelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turisti_AspNetUsers_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CapitaleTuristi",
                columns: table => new
                {
                    CapitalaTuristId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapitalaId = table.Column<int>(nullable: false),
                    TuristId = table.Column<int>(nullable: false),
                    Zile_Petrecute = table.Column<int>(nullable: false),
                    Calificativ_Acordat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitaleTuristi", x => x.CapitalaTuristId);
                    table.ForeignKey(
                        name: "FK_CapitaleTuristi_Capitale_CapitalaId",
                        column: x => x.CapitalaId,
                        principalTable: "Capitale",
                        principalColumn: "CapitalaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapitaleTuristi_Turisti_TuristId",
                        column: x => x.TuristId,
                        principalTable: "Turisti",
                        principalColumn: "TuristId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapitaleTuristi_CapitalaId",
                table: "CapitaleTuristi",
                column: "CapitalaId");

            migrationBuilder.CreateIndex(
                name: "IX_CapitaleTuristi_TuristId",
                table: "CapitaleTuristi",
                column: "TuristId");

            migrationBuilder.CreateIndex(
                name: "IX_Intrebari_UtilizatorId",
                table: "Intrebari",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Raspunsuri_IntrebareId",
                table: "Raspunsuri",
                column: "IntrebareId");

            migrationBuilder.CreateIndex(
                name: "IX_Raspunsuri_UtilizatorId",
                table: "Raspunsuri",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turisti_NivelId",
                table: "Turisti",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Turisti_UtilizatorId",
                table: "Turisti",
                column: "UtilizatorId",
                unique: true,
                filter: "[UtilizatorId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapitaleTuristi");

            migrationBuilder.DropTable(
                name: "Raspunsuri");

            migrationBuilder.DropTable(
                name: "Capitale");

            migrationBuilder.DropTable(
                name: "Turisti");

            migrationBuilder.DropTable(
                name: "Intrebari");

            migrationBuilder.DropTable(
                name: "Nivele");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Numar_Intrebari",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Numar_Raspunsuri",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nume",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenume",
                table: "AspNetUsers");
        }
    }
}
