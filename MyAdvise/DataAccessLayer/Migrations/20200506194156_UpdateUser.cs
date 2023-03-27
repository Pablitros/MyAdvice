using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Models.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "DocType",
                table: "User",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 20, nullable: true),
                    PhoneName = table.Column<string>(maxLength: 20, nullable: true),
                    CIF = table.Column<string>(maxLength: 20, nullable: true),
                    BusinessEmail = table.Column<string>(maxLength: 20, nullable: true),
                    BusinessRegisterDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Business_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentation",
                columns: table => new
                {
                    DocumentationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    DescriptionA = table.Column<string>(maxLength: 20, nullable: false),
                    DescriptionB = table.Column<string>(maxLength: 20, nullable: false),
                    Link = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<string>(maxLength: 20, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DocumentationId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentation", x => x.DocumentationId);
                    table.ForeignKey(
                        name: "FK_Documentation_Documentation_DocumentationId1",
                        column: x => x.DocumentationId1,
                        principalTable: "Documentation",
                        principalColumn: "DocumentationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Business_UserId",
                table: "Business",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_DocumentationId1",
                table: "Documentation",
                column: "DocumentationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_UserId",
                table: "Documentation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Documentation");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.AlterColumn<bool>(
                name: "DocType",
                table: "User",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
