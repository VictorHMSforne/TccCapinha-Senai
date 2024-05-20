using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace LanchesMac.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES('Padrão','Disponíveis em várias cores, as capinhas  combinam proteção e estilo de maneira simples e versátil')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES('Tech','Com um visual moderno e tecnológico, as capinhas estilo tech combinam segurança máxima com um estilo arrojado.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
