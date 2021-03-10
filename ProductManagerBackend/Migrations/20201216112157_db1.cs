using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagerBackend.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Brands_Tbl_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Tbl_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Products_Tbl_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Tbl_Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Brands_CompanyId",
                table: "Tbl_Brands",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_BrandId",
                table: "Tbl_Products",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Products");

            migrationBuilder.DropTable(
                name: "Tbl_Brands");

            migrationBuilder.DropTable(
                name: "Tbl_Companies");
        }
    }
}
