using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Models.Migrations
{
    public partial class UpdatedDocumentsBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_Documentation_DocumentationId",
                table: "Business");

            migrationBuilder.DropIndex(
                name: "IX_Business_DocumentationId",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Documentation");

            migrationBuilder.DropColumn(
                name: "DocumentationId",
                table: "Business");

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Documentation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DocumentationCheck",
                table: "Documentation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_BusinessId",
                table: "Documentation",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentation_Business_BusinessId",
                table: "Documentation",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentation_Business_BusinessId",
                table: "Documentation");

            migrationBuilder.DropIndex(
                name: "IX_Documentation_BusinessId",
                table: "Documentation");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Documentation");

            migrationBuilder.DropColumn(
                name: "DocumentationCheck",
                table: "Documentation");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Documentation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentationId",
                table: "Business",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Business_DocumentationId",
                table: "Business",
                column: "DocumentationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_Documentation_DocumentationId",
                table: "Business",
                column: "DocumentationId",
                principalTable: "Documentation",
                principalColumn: "DocumentationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
