using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_PrakticniDioIspita_2017_01_24.Migrations
{
    public partial class prv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odjeljenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NastavnikId = table.Column<int>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true),
                    Razred = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeljenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Nastavnik_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Nastavnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ucenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucenik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Angazovan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NastavnikId = table.Column<int>(nullable: true),
                    OdjeljenjeId = table.Column<int>(nullable: true),
                    PredmetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angazovan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Angazovan_Nastavnik_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Nastavnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Angazovan_Odjeljenje_OdjeljenjeId",
                        column: x => x.OdjeljenjeId,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Angazovan_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpisUOdjeljenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojUDnevniku = table.Column<int>(nullable: false),
                    OdjeljenjeId = table.Column<int>(nullable: false),
                    UcenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisUOdjeljenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpisUOdjeljenje_Odjeljenje_OdjeljenjeId",
                        column: x => x.OdjeljenjeId,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisUOdjeljenje_Ucenik_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Ucenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdrzaniCas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AngazovanId = table.Column<int>(nullable: true),
                    datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdrzaniCas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdrzaniCas_Angazovan_AngazovanId",
                        column: x => x.AngazovanId,
                        principalTable: "Angazovan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdrzaniCasDetalj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ocjena = table.Column<int>(nullable: true),
                    OdrzaniCasId = table.Column<int>(nullable: false),
                    Odsutan = table.Column<bool>(nullable: false),
                    OpravdanoOdsutan = table.Column<bool>(nullable: true),
                    UpisUOdjeljenjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdrzaniCasDetalj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdrzaniCasDetalj_OdrzaniCas_OdrzaniCasId",
                        column: x => x.OdrzaniCasId,
                        principalTable: "OdrzaniCas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdrzaniCasDetalj_UpisUOdjeljenje_UpisUOdjeljenjeId",
                        column: x => x.UpisUOdjeljenjeId,
                        principalTable: "UpisUOdjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angazovan_NastavnikId",
                table: "Angazovan",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Angazovan_OdjeljenjeId",
                table: "Angazovan",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Angazovan_PredmetId",
                table: "Angazovan",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_NastavnikId",
                table: "Odjeljenje",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzaniCas_AngazovanId",
                table: "OdrzaniCas",
                column: "AngazovanId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzaniCasDetalj_OdrzaniCasId",
                table: "OdrzaniCasDetalj",
                column: "OdrzaniCasId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzaniCasDetalj_UpisUOdjeljenjeId",
                table: "OdrzaniCasDetalj",
                column: "UpisUOdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisUOdjeljenje_OdjeljenjeId",
                table: "UpisUOdjeljenje",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisUOdjeljenje_UcenikId",
                table: "UpisUOdjeljenje",
                column: "UcenikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdrzaniCasDetalj");

            migrationBuilder.DropTable(
                name: "OdrzaniCas");

            migrationBuilder.DropTable(
                name: "UpisUOdjeljenje");

            migrationBuilder.DropTable(
                name: "Angazovan");

            migrationBuilder.DropTable(
                name: "Ucenik");

            migrationBuilder.DropTable(
                name: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Predmet");
        }
    }
}
