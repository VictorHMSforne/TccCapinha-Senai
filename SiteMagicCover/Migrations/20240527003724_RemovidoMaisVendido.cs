using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class RemovidoMaisVendido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaisVendido",
                table: "Capinhas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MaisVendido",
                table: "Capinhas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
