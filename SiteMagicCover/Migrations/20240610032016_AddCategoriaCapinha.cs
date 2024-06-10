using Microsoft.EntityFrameworkCore.Migrations;
using Mysqlx.Crud;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class AddCategoriaCapinha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
               "VALUES('Personalizada','Capinhas Desenvolvidas pelos Usuários')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
