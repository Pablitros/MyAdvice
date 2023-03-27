using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Models.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BusinessEmail",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "CIF",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "PhoneName",
                table: "Business");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Documentation",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Documentation",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Documentation",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionB",
                table: "Documentation",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionA",
                table: "Documentation",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "DocumentationId",
                table: "Business",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusinessPremises",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false),
                    PremisesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPremises", x => new { x.BusinessId, x.PremisesId });
                    table.ForeignKey(
                        name: "FK_BusinessPremises_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessPremises_Premises_PremisesId",
                        column: x => x.PremisesId,
                        principalTable: "Premises",
                        principalColumn: "PremisesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixedAssets",
                columns: table => new
                {
                    AssetsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssetsPrice = table.Column<float>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAssets", x => x.AssetsId);
                    table.ForeignKey(
                        name: "FK_FixedAssets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContractType = table.Column<string>(nullable: true),
                    WorkerPrice = table.Column<float>(nullable: false),
                    SocialInsurance = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkersId);
                    table.ForeignKey(
                        name: "FK_Workers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessFixedAssets",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false),
                    FixedAssetsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessFixedAssets", x => new { x.FixedAssetsId, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_BusinessFixedAssets_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessFixedAssets_FixedAssets_FixedAssetsId",
                        column: x => x.FixedAssetsId,
                        principalTable: "FixedAssets",
                        principalColumn: "AssetsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessWorkers",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false),
                    WorkersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessWorkers", x => new { x.BusinessId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_BusinessWorkers_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessWorkers_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "WorkersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_DocumentationId",
                table: "Business",
                column: "DocumentationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFixedAssets_BusinessId",
                table: "BusinessFixedAssets",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPremises_PremisesId",
                table: "BusinessPremises",
                column: "PremisesId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessWorkers_WorkersId",
                table: "BusinessWorkers",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssets_UserId",
                table: "FixedAssets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_Documentation_DocumentationId",
                table: "Business",
                column: "DocumentationId",
                principalTable: "Documentation",
                principalColumn: "DocumentationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_Documentation_DocumentationId",
                table: "Business");

            migrationBuilder.DropTable(
                name: "BusinessFixedAssets");

            migrationBuilder.DropTable(
                name: "BusinessPremises");

            migrationBuilder.DropTable(
                name: "BusinessWorkers");

            migrationBuilder.DropTable(
                name: "FixedAssets");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Business_DocumentationId",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "DocumentationId",
                table: "Business");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Documentation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Documentation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Documentation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionB",
                table: "Documentation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionA",
                table: "Documentation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 800);

            migrationBuilder.AddColumn<string>(
                name: "BusinessEmail",
                table: "Business",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CIF",
                table: "Business",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneName",
                table: "Business",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
