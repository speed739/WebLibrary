using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomagajLocaly.Data.Migrations
{
    public partial class UserToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Companies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");
        }
    }
}
