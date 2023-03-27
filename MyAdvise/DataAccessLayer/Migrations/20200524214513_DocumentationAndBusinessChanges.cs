using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Models.Migrations
{
    public partial class DocumentationAndBusinessChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Documentation");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Business",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Business",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Business");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Documentation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
