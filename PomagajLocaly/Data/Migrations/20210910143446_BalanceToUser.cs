using Microsoft.EntityFrameworkCore.Migrations;

namespace PomagajLocaly.Data.Migrations
{
    public partial class BalanceToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");
        }
    }
}
