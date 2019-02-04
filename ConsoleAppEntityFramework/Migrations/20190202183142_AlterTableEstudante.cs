using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppEntityFramework.Migrations
{
    public partial class AlterTableEstudante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaExcluido",
                table: "Estudantes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaExcluido",
                table: "Estudantes");
        }
    }
}
