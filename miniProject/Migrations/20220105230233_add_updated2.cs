using Microsoft.EntityFrameworkCore.Migrations;

namespace miniProject.Migrations
{
    public partial class add_updated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_informations_companies_CompanyID",
                table: "informations");

            migrationBuilder.DropIndex(
                name: "IX_informations_CompanyID",
                table: "informations");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "informations");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "informations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "informations");

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "informations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_informations_CompanyID",
                table: "informations",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_informations_companies_CompanyID",
                table: "informations",
                column: "CompanyID",
                principalTable: "companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
