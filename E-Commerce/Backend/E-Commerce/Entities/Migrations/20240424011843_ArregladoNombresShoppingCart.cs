using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class ArregladoNombresShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_item_shopping_cart_ShopingCartId",
                table: "cart_item");

            migrationBuilder.RenameColumn(
                name: "ShopingCartId",
                table: "cart_item",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_cart_item_ShopingCartId",
                table: "cart_item",
                newName: "IX_cart_item_ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_item_shopping_cart_ShoppingCartId",
                table: "cart_item",
                column: "ShoppingCartId",
                principalTable: "shopping_cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_item_shopping_cart_ShoppingCartId",
                table: "cart_item");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "cart_item",
                newName: "ShopingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_cart_item_ShoppingCartId",
                table: "cart_item",
                newName: "IX_cart_item_ShopingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_item_shopping_cart_ShopingCartId",
                table: "cart_item",
                column: "ShopingCartId",
                principalTable: "shopping_cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
