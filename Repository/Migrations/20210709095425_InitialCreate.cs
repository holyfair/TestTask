using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseCustomers",
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
                    table.PrimaryKey("PK_BaseCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MrGreenCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BaseCustomerInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrGreenCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MrGreenCustomers_BaseCustomers_BaseCustomerInfoId",
                        column: x => x.BaseCustomerInfoId,
                        principalTable: "BaseCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedBetCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoriteFootballTeam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseCustomerInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedBetCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedBetCustomers_BaseCustomers_BaseCustomerInfoId",
                        column: x => x.BaseCustomerInfoId,
                        principalTable: "BaseCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MrGreenCustomers_BaseCustomerInfoId",
                table: "MrGreenCustomers",
                column: "BaseCustomerInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RedBetCustomers_BaseCustomerInfoId",
                table: "RedBetCustomers",
                column: "BaseCustomerInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MrGreenCustomers");

            migrationBuilder.DropTable(
                name: "RedBetCustomers");

            migrationBuilder.DropTable(
                name: "BaseCustomers");
        }
    }
}
