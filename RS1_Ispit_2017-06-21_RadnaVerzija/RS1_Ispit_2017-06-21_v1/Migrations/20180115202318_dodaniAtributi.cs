using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_20170621_v1.Migrations
{
    public partial class dodaniAtributi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Bodovi",
                table: "MaturskiIspitStavka",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Oslobodjen",
                table: "MaturskiIspitStavka",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bodovi",
                table: "MaturskiIspitStavka");

            migrationBuilder.DropColumn(
                name: "Oslobodjen",
                table: "MaturskiIspitStavka");
        }
    }
}
