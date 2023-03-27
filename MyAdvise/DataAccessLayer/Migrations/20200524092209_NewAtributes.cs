using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Models.Migrations
{
    public partial class NewAtributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkB",
                table: "Documentation",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkB",
                table: "Documentation");
        }
    }
}
