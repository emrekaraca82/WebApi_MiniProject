using Microsoft.EntityFrameworkCore.Migrations;

namespace miniProject.Migrations
{
    public partial class add_updated1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
