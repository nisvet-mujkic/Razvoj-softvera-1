using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_20170621_v1.Migrations
{
    public partial class pva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nastavnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImePrezime = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastavnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ucenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImePrezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucenik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odjeljenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NastavnikId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjeljenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odjeljenje_Nastavnik_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Nastavnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpisUOdjeljenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojUDnevniku = table.Column<int>(nullable: false),
                    OdjeljenjeId = table.Column<int>(nullable: false),
                    OpciUspjeh = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_NastavnikId",
                table: "Odjeljenje",
                column: "NastavnikId");

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
                name: "UpisUOdjeljenje");

            migrationBuilder.DropTable(
                name: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Ucenik");

            migrationBuilder.DropTable(
                name: "Nastavnik");
        }
    }
}
