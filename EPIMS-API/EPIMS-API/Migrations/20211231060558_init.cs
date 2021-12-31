using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EPIMS_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryNo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryNo);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductNo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ModelName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ShopCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Maker = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CategoryFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductNo);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductDataProductNo = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    CountName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataSheetPath = table.Column<string>(type: "text", nullable: true),
                    SpecDesc = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductDataProductNo",
                        column: x => x.ProductDataProductNo,
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductDataProductNo",
                table: "ProductDetail",
                column: "ProductDataProductNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
