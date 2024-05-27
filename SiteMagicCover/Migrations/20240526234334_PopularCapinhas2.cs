using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class PopularCapinhas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE capinhas SET MaisVendido = 1 WHERE CapinhaId = 1");
            migrationBuilder.Sql("UPDATE capinhas SET MaisVendido = 0 WHERE CapinhaId = 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM capinhas");
        }
    }
}
