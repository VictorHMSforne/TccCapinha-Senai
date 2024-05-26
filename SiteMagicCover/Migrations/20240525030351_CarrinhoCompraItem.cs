using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class CarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItens",
                columns: table => new
                {
                    CarinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CapinhaId = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<string>(type: "longtext", nullable: true),
                    CarrinhoCompraId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItens", x => x.CarinhoCompraItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItens_Capinhas_CapinhaId",
                        column: x => x.CapinhaId,
                        principalTable: "Capinhas",
                        principalColumn: "CapinhaId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_CapinhaId",
                table: "CarrinhoCompraItens",
                column: "CapinhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItens");
        }
    }
}
