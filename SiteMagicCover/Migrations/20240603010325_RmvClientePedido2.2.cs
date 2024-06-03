using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class RmvClientePedido22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapinhaPersoId",
                table: "ClientePedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapinhaPersoId",
                table: "ClientePedido",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
