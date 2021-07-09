using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MrGreenBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BrandBaseInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrGreenBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MrGreenBrands_Brands_BrandBaseInfoId",
                        column: x => x.BrandBaseInfoId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedBetBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoriteFootballTeam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BrandBaseInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedBetBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedBetBrands_Brands_BrandBaseInfoId",
                        column: x => x.BrandBaseInfoId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MrGreenBrands_BrandBaseInfoId",
                table: "MrGreenBrands",
                column: "BrandBaseInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RedBetBrands_BrandBaseInfoId",
                table: "RedBetBrands",
                column: "BrandBaseInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MrGreenBrands");

            migrationBuilder.DropTable(
                name: "RedBetBrands");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
