using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientePedido",
                columns: table => new
                {
                    ClientePedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CapinhaId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "double", nullable: false),
                    PedidoTotal = table.Column<double>(type: "double", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    TotalItensPedido = table.Column<int>(type: "int", nullable: false),
                    PedidoEnviado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PedidoEntregueEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePedido", x => x.ClientePedidoId);
                    table.ForeignKey(
                        name: "FK_ClientePedido_Capinhas_CapinhaId",
                        column: x => x.CapinhaId,
                        principalTable: "Capinhas",
                        principalColumn: "CapinhaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientePedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientesEndereco",
                columns: table => new
                {
                    ClienteEnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Estado = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Rua = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Numero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Informacao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesEndereco", x => x.ClienteEnderecoId);
                    table.ForeignKey(
                        name: "FK_ClientesEndereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePedido_CapinhaId",
                table: "ClientePedido",
                column: "CapinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePedido_ClienteId",
                table: "ClientePedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEndereco_ClienteId",
                table: "ClientesEndereco",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientePedido");

            migrationBuilder.DropTable(
                name: "ClientesEndereco");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
