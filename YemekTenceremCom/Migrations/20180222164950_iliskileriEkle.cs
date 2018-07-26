using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YemekTenceremCom.Migrations
{
    public partial class iliskileriEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YemekId",
                table: "Yorumlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_YemekId",
                table: "Yorumlar",
                column: "YemekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Yemekler_YemekId",
                table: "Yorumlar",
                column: "YemekId",
                principalTable: "Yemekler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Yemekler_YemekId",
                table: "Yorumlar");

            migrationBuilder.DropIndex(
                name: "IX_Yorumlar_YemekId",
                table: "Yorumlar");

            migrationBuilder.DropColumn(
                name: "YemekId",
                table: "Yorumlar");
        }
    }
}
