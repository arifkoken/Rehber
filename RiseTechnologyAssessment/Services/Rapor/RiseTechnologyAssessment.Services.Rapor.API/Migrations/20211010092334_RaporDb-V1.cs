using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiseTechnologyAssessment.Services.Rapor.API.Migrations
{
    public partial class RaporDbV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rapor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonumId = table.Column<int>(type: "int", nullable: false),
                    KonumAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToplamKisiSayisi = table.Column<int>(type: "int", nullable: true),
                    ToplamTelefonNoSayisi = table.Column<int>(type: "int", nullable: true),
                    TalepZamani = table.Column<DateTime>(type: "datetime", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapor");
        }
    }
}
