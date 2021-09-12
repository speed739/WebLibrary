using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomagajLocaly.Data.Migrations
{
    public partial class Tabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nip = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    BankAccount = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferTypes",
                columns: table => new
                {
                    OfferTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTypes", x => x.OfferTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    OfferTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_OfferTypes_OfferTypeId",
                        column: x => x.OfferTypeId,
                        principalTable: "OfferTypes",
                        principalColumn: "OfferTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OfferId = table.Column<int>(type: "INTEGER", nullable: true),
                    StartAmount = table.Column<double>(type: "REAL", nullable: true),
                    CurrentAmount = table.Column<double>(type: "REAL", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OfferId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Vouchers_Offers_OfferId1",
                        column: x => x.OfferId1,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_OfferId1",
                table: "Vouchers",
                column: "OfferId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "OfferTypes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AspNetUsers");
        }
    }
}
