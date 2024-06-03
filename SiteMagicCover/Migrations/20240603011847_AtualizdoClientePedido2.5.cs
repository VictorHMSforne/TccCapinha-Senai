using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class AtualizdoClientePedido25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapinhaPersoId",
                table: "ClientePedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CapinhaPersoId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "CapinhasPersonalizadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientePedido_CapinhaPersoId",
                table: "ClientePedido",
                column: "CapinhaPersoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_CapinhaPersoId",
                table: "CarrinhoCompraItens",
                column: "CapinhaPersoId");

            migrationBuilder.CreateIndex(
                name: "IX_CapinhasPersonalizadas_ClienteId",
                table: "CapinhasPersonalizadas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CapinhasPersonalizadas_Cliente_ClienteId",
                table: "CapinhasPersonalizadas",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_CapinhasPersonalizadas_CapinhaPersoId",
                table: "CarrinhoCompraItens",
                column: "CapinhaPersoId",
                principalTable: "CapinhasPersonalizadas",
                principalColumn: "CapinhaPersoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientePedido_CapinhasPersonalizadas_CapinhaPersoId",
                table: "ClientePedido",
                column: "CapinhaPersoId",
                principalTable: "CapinhasPersonalizadas",
                principalColumn: "CapinhaPersoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapinhasPersonalizadas_Cliente_ClienteId",
                table: "CapinhasPersonalizadas");

            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_CapinhasPersonalizadas_CapinhaPersoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientePedido_CapinhasPersonalizadas_CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropIndex(
                name: "IX_ClientePedido_CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompraItens_CapinhaPersoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropIndex(
                name: "IX_CapinhasPersonalizadas_ClienteId",
                table: "CapinhasPersonalizadas");

            migrationBuilder.DropColumn(
                name: "CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropColumn(
                name: "CapinhaPersoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "CapinhasPersonalizadas");
        }
    }
}
