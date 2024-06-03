using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class AdicionadoCapinhaPersonalizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapinhasPersonalizadas",
                columns: table => new
                {
                    CapinhaPersoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    ImagemUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImagemMockup = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImagemFinal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapinhasPersonalizadas", x => x.CapinhaPersoId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapinhasPersonalizadas");
        }
    }
}
