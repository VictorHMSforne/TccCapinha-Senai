using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class PopularCapinha3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE capinhas SET NomeCelular = 'Capinha Preta Tech' WHERE CapinhaId = 1");
            migrationBuilder.Sql("UPDATE capinhas SET NomeCelular = 'Capinha Verde Padrão' WHERE CapinhaId = 2");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM capinhas");
        }
    }
}
