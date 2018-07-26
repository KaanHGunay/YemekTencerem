using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YemekTenceremCom.Migrations
{
    public partial class Yorum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YorumOnay",
                table: "Yorumlar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "YorumEkleViewModel",
                columns: table => new
                {
                    YemekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YapilanYorum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YemekAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YemekResmi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YorumEkleViewModel", x => x.YemekID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YorumEkleViewModel");

            migrationBuilder.DropColumn(
                name: "YorumOnay",
                table: "Yorumlar");
        }
    }
}
