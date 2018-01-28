using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ljekar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ljekar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacijent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPretrage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPretrage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabPretraga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MjernaJedinica = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    ReferentnaVrijednostMax = table.Column<double>(nullable: true),
                    ReferentnaVrijednostMin = table.Column<double>(nullable: true),
                    VrstaPretrageId = table.Column<int>(nullable: false),
                    VrstaVr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabPretraga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabPretraga_VrstaPretrage_VrstaPretrageId",
                        column: x => x.VrstaPretrageId,
                        principalTable: "VrstaPretrage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uputnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRezultata = table.Column<DateTime>(nullable: true),
                    DatumUputnice = table.Column<DateTime>(nullable: false),
                    IsGotovNalaz = table.Column<bool>(nullable: false),
                    LaboratorijLjekarId = table.Column<int>(nullable: true),
                    PacijentId = table.Column<int>(nullable: false),
                    UputioLjekarId = table.Column<int>(nullable: false),
                    VrstaPretrageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uputnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uputnica_Ljekar_LaboratorijLjekarId",
                        column: x => x.LaboratorijLjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uputnica_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uputnica_Ljekar_UputioLjekarId",
                        column: x => x.UputioLjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uputnica_VrstaPretrage_VrstaPretrageId",
                        column: x => x.VrstaPretrageId,
                        principalTable: "VrstaPretrage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modalitet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsReferentnaVrijednost = table.Column<bool>(nullable: false),
                    LabPretragaId = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalitet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalitet_LabPretraga_LabPretragaId",
                        column: x => x.LabPretragaId,
                        principalTable: "LabPretraga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezultatPretrage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabPretragaId = table.Column<int>(nullable: false),
                    ModalitetId = table.Column<int>(nullable: true),
                    NumerickaVrijednost = table.Column<double>(nullable: true),
                    UputnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezultatPretrage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezultatPretrage_LabPretraga_LabPretragaId",
                        column: x => x.LabPretragaId,
                        principalTable: "LabPretraga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezultatPretrage_Modalitet_ModalitetId",
                        column: x => x.ModalitetId,
                        principalTable: "Modalitet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezultatPretrage_Uputnica_UputnicaId",
                        column: x => x.UputnicaId,
                        principalTable: "Uputnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabPretraga_VrstaPretrageId",
                table: "LabPretraga",
                column: "VrstaPretrageId");

            migrationBuilder.CreateIndex(
                name: "IX_Modalitet_LabPretragaId",
                table: "Modalitet",
                column: "LabPretragaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatPretrage_LabPretragaId",
                table: "RezultatPretrage",
                column: "LabPretragaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatPretrage_ModalitetId",
                table: "RezultatPretrage",
                column: "ModalitetId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatPretrage_UputnicaId",
                table: "RezultatPretrage",
                column: "UputnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_LaboratorijLjekarId",
                table: "Uputnica",
                column: "LaboratorijLjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_PacijentId",
                table: "Uputnica",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_UputioLjekarId",
                table: "Uputnica",
                column: "UputioLjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_VrstaPretrageId",
                table: "Uputnica",
                column: "VrstaPretrageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezultatPretrage");

            migrationBuilder.DropTable(
                name: "Modalitet");

            migrationBuilder.DropTable(
                name: "Uputnica");

            migrationBuilder.DropTable(
                name: "LabPretraga");

            migrationBuilder.DropTable(
                name: "Ljekar");

            migrationBuilder.DropTable(
                name: "Pacijent");

            migrationBuilder.DropTable(
                name: "VrstaPretrage");
        }
    }
}
