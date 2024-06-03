using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class RemovendoErros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientePedido_CapinhasPersonalizadas_CapinhaPersonalizadaCap~",
                table: "ClientePedido");

            migrationBuilder.DropIndex(
                name: "IX_ClientePedido_CapinhaPersonalizadaCapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropColumn(
                name: "CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropColumn(
                name: "CapinhaPersonalizadaCapinhaPersoId",
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

            migrationBuilder.AddColumn<int>(
                name: "CapinhaPersonalizadaCapinhaPersoId",
                table: "ClientePedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientePedido_CapinhaPersonalizadaCapinhaPersoId",
                table: "ClientePedido",
                column: "CapinhaPersonalizadaCapinhaPersoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientePedido_CapinhasPersonalizadas_CapinhaPersonalizadaCap~",
                table: "ClientePedido",
                column: "CapinhaPersonalizadaCapinhaPersoId",
                principalTable: "CapinhasPersonalizadas",
                principalColumn: "CapinhaPersoId");
        }
    }
}
