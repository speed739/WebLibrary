using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomagajLocaly.Data.Migrations
{
    public partial class newGuido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_OfferTypes_OfferTypeId1",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OfferTypeId1",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferTypeId1",
                table: "Offers");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfferTypeId",
                table: "Offers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_OfferTypes_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId",
                principalTable: "OfferTypes",
                principalColumn: "OfferTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_OfferTypes_OfferTypeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "OfferTypeId",
                table: "Offers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfferTypeId1",
                table: "Offers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferTypeId1",
                table: "Offers",
                column: "OfferTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_OfferTypes_OfferTypeId1",
                table: "Offers",
                column: "OfferTypeId1",
                principalTable: "OfferTypes",
                principalColumn: "OfferTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
