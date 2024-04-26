using E_Commerce.Responses;
using Entities.Dto.CartItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace E_Commerce.Controllers
{
    [Route( "api/cart" )]
    [ApiController]
    public class ShoppingCartController : ControllerBase {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController( ShoppingCartService shoppingCartService ) {
            _shoppingCartService = shoppingCartService;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewProductInCart( [FromBody] CartItemCreationDto cartItemCreationDto ) {
            //await _shoppingCartService.CreateShoppingCart(cartItemCreationDto.UserId);
            await _shoppingCartService.AddNewProduct( cartItemCreationDto );

            var shoppoingCart = await _shoppingCartService.GetShoppingCartDto( cartItemCreationDto.ShoppingCartId );

            return Ok( _shoppingCartService.ResponseCreate( shoppoingCart ) );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopCart(int id) {
            var shopCart = await _shoppingCartService.GetShoppingCartDto(id);

            return Ok( _shoppingCartService.ResponseGetById( id, shopCart ) );
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem( [FromQuery] int shopCartId, [FromQuery] int itemCartId  ) {
            await _shoppingCartService.DeleteProductInCart(shopCartId, itemCartId );

            var shoppoingCart = await _shoppingCartService.GetShoppingCartDto( shopCartId );

            return Ok( new Response() { StatusCode = 200, Message = "Se ha eliminado el item del cart correctamente.", Data = shoppoingCart} );
        }
    }
}
