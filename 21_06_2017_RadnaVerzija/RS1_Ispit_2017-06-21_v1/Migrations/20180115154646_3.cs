using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_20170621_v1.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaturskiIspit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    NastavnikID = table.Column<int>(nullable: false),
                    OdjeljenjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturskiIspit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaturskiIspit_Nastavnik_NastavnikID",
                        column: x => x.NastavnikID,
                        principalTable: "Nastavnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaturskiIspit_Odjeljenje_OdjeljenjeId",
                        column: x => x.OdjeljenjeId,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaturskiIspitStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaturskiIspitId = table.Column<int>(nullable: false),
                    UpisUOdjeljenjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturskiIspitStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaturskiIspitStavka_MaturskiIspit_MaturskiIspitId",
                        column: x => x.MaturskiIspitId,
                        principalTable: "MaturskiIspit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaturskiIspitStavka_UpisUOdjeljenje_UpisUOdjeljenjeId",
                        column: x => x.UpisUOdjeljenjeId,
                        principalTable: "UpisUOdjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_NastavnikID",
                table: "MaturskiIspit",
                column: "NastavnikID");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_OdjeljenjeId",
                table: "MaturskiIspit",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspitStavka_MaturskiIspitId",
                table: "MaturskiIspitStavka",
                column: "MaturskiIspitId");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspitStavka_UpisUOdjeljenjeId",
                table: "MaturskiIspitStavka",
                column: "UpisUOdjeljenjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaturskiIspitStavka");

            migrationBuilder.DropTable(
                name: "MaturskiIspit");
        }
    }
}
