using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.EF.Migrations
{
    public partial class AddJsonDiagramFieldInDiagramTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JsonDiagram",
                table: "Diagram",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JsonDiagram",
                table: "Diagram");
        }
    }
}
