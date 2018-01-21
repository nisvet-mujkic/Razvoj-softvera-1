using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ispit_2017_02_15.Migrations
{
    public partial class initialž : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdrzaniCasovi_Angazovan_AngazovanId",
                table: "OdrzaniCasovi");

            migrationBuilder.AlterColumn<int>(
                name: "AngazovanId",
                table: "OdrzaniCasovi",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OdrzaniCasovi_Angazovan_AngazovanId",
                table: "OdrzaniCasovi",
                column: "AngazovanId",
                principalTable: "Angazovan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdrzaniCasovi_Angazovan_AngazovanId",
                table: "OdrzaniCasovi");

            migrationBuilder.AlterColumn<int>(
                name: "AngazovanId",
                table: "OdrzaniCasovi",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OdrzaniCasovi_Angazovan_AngazovanId",
                table: "OdrzaniCasovi",
                column: "AngazovanId",
                principalTable: "Angazovan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
