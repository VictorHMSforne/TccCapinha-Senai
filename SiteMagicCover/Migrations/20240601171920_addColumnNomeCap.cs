using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMagicCover.Migrations
{
    public partial class addColumnNomeCap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCelular",
                table: "Capinhas",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCelular",
                table: "Capinhas");
        }
    }
}
