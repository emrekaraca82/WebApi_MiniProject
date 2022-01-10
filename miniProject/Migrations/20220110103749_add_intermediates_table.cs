using Microsoft.EntityFrameworkCore.Migrations;

namespace miniProject.Migrations
{
    public partial class add_intermediates_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "intermediates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    InformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intermediates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_intermediates_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_intermediates_informations_InformationId",
                        column: x => x.InformationId,
                        principalTable: "informations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_intermediates_CompanyId",
                table: "intermediates",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_intermediates_InformationId",
                table: "intermediates",
                column: "InformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "intermediates");
        }
    }
}
