using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppEntityFramework.Migrations
{
    public partial class AddColumnAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "EstudantesCursos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "EstudantesCursos");
        }
    }
}
