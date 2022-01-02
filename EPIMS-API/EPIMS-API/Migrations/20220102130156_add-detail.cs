using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIMS_API.Migrations
{
    public partial class adddetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetail_Product_ProductDataProductNo",
                table: "ProductDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetail_ProductDataProductNo",
                table: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "ProductDataProductNo",
                table: "ProductDetail");

            migrationBuilder.AddColumn<int>(
                name: "ProductNo",
                table: "ProductDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductNo",
                table: "ProductDetail",
                column: "ProductNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetail_Product_ProductNo",
                table: "ProductDetail",
                column: "ProductNo",
                principalTable: "Product",
                principalColumn: "ProductNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetail_Product_ProductNo",
                table: "ProductDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetail_ProductNo",
                table: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "ProductNo",
                table: "ProductDetail");

            migrationBuilder.AddColumn<int>(
                name: "ProductDataProductNo",
                table: "ProductDetail",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductDataProductNo",
                table: "ProductDetail",
                column: "ProductDataProductNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetail_Product_ProductDataProductNo",
                table: "ProductDetail",
                column: "ProductDataProductNo",
                principalTable: "Product",
                principalColumn: "ProductNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
