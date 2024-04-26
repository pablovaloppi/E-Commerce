using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class CambioImagenesProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_image");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "image",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_image_ProductId",
                table: "image",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_image_product_ProductId",
                table: "image",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_product_ProductId",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_ProductId",
                table: "image");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "image");

            migrationBuilder.CreateTable(
                name: "product_image",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_image", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_product_image_image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_image_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_image_ImageId",
                table: "product_image",
                column: "ImageId");
        }
    }
}
