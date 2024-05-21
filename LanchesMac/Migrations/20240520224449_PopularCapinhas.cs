using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class PopularCapinhas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO capinhas(CategoriaId,Marca,Modelo,Preco,ImagemUrl,ImagemThumbUrl,Disponibilidade) VALUES(1,'Samsung','S24','29.99','PretoSs24','PretoSs24',1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM capinhas");
        }
    }
}
