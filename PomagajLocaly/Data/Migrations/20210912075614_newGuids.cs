using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomagajLocaly.Data.Migrations
{
    public partial class newGuids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Offers_OfferId1",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_OfferId1",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "OfferId1",
                table: "Vouchers");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfferId",
                table: "Vouchers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Vouchers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_OfferId",
                table: "Vouchers",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Offers_OfferId",
                table: "Vouchers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "OfferId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Offers_OfferId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_OfferId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vouchers");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Vouchers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId1",
                table: "Vouchers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_OfferId1",
                table: "Vouchers",
                column: "OfferId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Offers_OfferId1",
                table: "Vouchers",
                column: "OfferId1",
                principalTable: "Offers",
                principalColumn: "OfferId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
