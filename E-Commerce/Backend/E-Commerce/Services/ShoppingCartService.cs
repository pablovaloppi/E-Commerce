using AutoMapper;
using Entities.Dto.CartItem;
using Entities.Dto.Products;
using Entities.Dto.ShoppingCart;
using Entities.Model;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShoppingCartService : BaseService<ShoppingCart>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly CartItemService _cartItemService;

        public ShoppingCartService( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper, CartItemService cartItemService) : base( logger ) { 
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _cartItemService = cartItemService;
        }

        public async Task CreateShoppingCart(int userId ) {
            var user = await _repository.User.GetByIdAsync( userId );
            IsNull( user, $"No se ha podido obtener el usuario de id: {userId}." );

            var cart = new ShoppingCart();
            cart.Total = 0;
            cart.UserId = userId;
            _repository.ShoppingCart.CreateShoppingCart( cart );
            await _repository.SaveAsync();

            await SetShoppingCartInUser(user);
        }

        public async Task<ShoppingCartDto> GetShoppingCartDto(int shopCartId ) {
            var result = await GetShoppingCart( shopCartId );

            return _mapper.Map<ShoppingCartDto>( result );
        }

        public async Task AddNewProduct(CartItemCreationDto cartItem ) {
            IsNull( cartItem, "Los datos del CartItem enviados son null." );

            var shoppingCart = await GetShoppingCart(cartItem.ShoppingCartId);

            IsNull( shoppingCart, "No se ha encontrado ningun carrito de compra." );

            cartItem.Id = IsInShoppingCart( shoppingCart, cartItem.ProductId );
            if( cartItem.Id != 0) {
                /* if( cartItem.Id is null ) {
                     _logger.LogError( "No hay suficientes cantidad productos para realizar este pedido." );
                     throw new ArgumentOutOfRangeException( "No hay suficientes cantidad productos para realizar este pedido." );
                 }
                 else {*/
                var quantityInShop = shoppingCart.CartItems.Where( item => item.ProductId == cartItem.ProductId ).FirstOrDefault().Quantity;

                    if( await _cartItemService.ThereIsStock( cartItem, quantityInShop ) ) {
                        await _cartItemService.UpdateQuantityCartItem( cartItem );
                    }
                //}
               
            }
            
           else {
                await _cartItemService.CreateCartItem( cartItem );

                await UpdateShoppingCart( cartItem.ShoppingCartId );

                _logger.LogInfo( "Se ha agregado un nuevo item en el shop correctamete." );
            }
        }

        public async Task DeleteProductInCart(int shopCartId, int itemCartId ) {
            await _cartItemService.DeleteItemCart( itemCartId );

            await UpdateShoppingCart( shopCartId );

            _logger.LogInfo( "Se ha eliminado un item en el shop correctamete." );
        }

        public async Task DeleteAllProductsInCart(int shopCartId ) {
            var shopCart = await _repository.ShoppingCart.GetShoppingCartByIdAsync( shopCartId );

            IsNull( shopCart, $"No se ha podido obtener el shopping cart de id: {shopCartId}" );

          

            await _cartItemService.DeleteAllItemCartByShopCartId( shopCart.CartItems );

            _logger.LogInfo( $"Se han borrado todo los items del shop cart de id: {shopCartId}." );

            await UpdateShoppingCart( shopCartId );

        }

        public async Task UpdateShoppingCart(ShoppingCartUpdateDto shopCart ) {
            IsNull( shopCart, "El Shopping cart es null." );

            var shop = await _repository.ShoppingCart.GetShoppingCartByIdAsync( shopCart.Id );

            IsNull( shop, $"No se encuentra un Shopping Cart con el id:{shopCart.Id}." );

            _mapper.Map( shopCart, shop );
              

            _repository.ShoppingCart.UpdateShopCart( shop );
            await _repository.SaveAsync();

            await _cartItemService.UpdateTotalPriceItems(shop.Id );

            shop.Total = CalculateTotal( shop.CartItems );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha actualizado el Shoping Cart de id: {shopCart.Id} correctamete." );
        }


        private int IsInShoppingCart(ShoppingCart cart, int productId) {
            var cartItem = cart.CartItems.Where( item => item.ProductId == productId );
            return cartItem.Count() > 0 ? cartItem.FirstOrDefault().Id : 0;       
        }

        private async Task<ShoppingCart> GetShoppingCart( int shopCartId ) {
            var cartItems = await _repository.ShoppingCart.GetShoppingCartByIdAsync( shopCartId ); 

            IsNull( cartItems, $"No se ha podido obtener el Shopping cart para el id: {shopCartId}" );

            _logger.LogInfo( $"Se ha obtendio el shopping cart de id: {shopCartId}" );

            return cartItems;
        }

        private float CalculateTotal( IEnumerable<CartItem> cartItems ) {

            return cartItems.ToList().Sum( item => item.TotalPrice );
        }

        private async Task UpdateShoppingCart(int shopCartId) {

            var shopCart = await GetShoppingCart( shopCartId );

            shopCart.Total = CalculateTotal( shopCart.CartItems );

            _repository.ShoppingCart.UpdateShopCart( shopCart );
            await _repository.SaveAsync();


        }
        private async Task SetShoppingCartInUser(User user ) {
            var shoppingCart = await _repository.ShoppingCart.GetShoppingCartByUserAsync( user.Id );

            User userUpdate = user;
            userUpdate.ShoppingCartId = shoppingCart.Id;
            _repository.User.UpdateUser( userUpdate );
            await _repository.SaveAsync();
        }


    }
}
