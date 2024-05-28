using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class PopularCapinha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO capinhas(CategoriaId,Marca,Modelo,Preco,ImagemUrl,ImagemThumbUrl,Disponibilidade) VALUES(2,'Samsung','S24','29.99','images/PretoSs24.jpg','PretoSs24',1)");
            migrationBuilder.Sql("INSERT INTO capinhas(CategoriaId,Marca,Modelo,Preco,ImagemUrl,ImagemThumbUrl,Disponibilidade) VALUES(1,'Iphone','14','31.50','images/VerdeIp14.jpg','VerdeIp14',1)");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM capinhas");
        }
    }
}
