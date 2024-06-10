using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class RmvCapinhaPersonalizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_CapinhasPersonalizadas_CapinhaPersoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientePedido_CapinhasPersonalizadas_CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropTable(
                name: "CapinhasPersonalizadas");

            migrationBuilder.DropIndex(
                name: "IX_ClientePedido_CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompraItens_CapinhaPersoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropColumn(
                name: "CapinhaPersoId",
                table: "ClientePedido");

            migrationBuilder.DropColumn(
                name: "CapinhaPersoId",
                table: "CarrinhoCompraItens");
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
                name: "CapinhaPersoId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CapinhasPersonalizadas",
                columns: table => new
                {
                    CapinhaPersoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ImagemFinal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImagemMockup = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImagemUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Marca = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapinhasPersonalizadas", x => x.CapinhaPersoId);
                    table.ForeignKey(
                        name: "FK_CapinhasPersonalizadas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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
    }
}
