using AutoMapper;
using Entities.Dto.CartItem;
using Entities.Dto.Products;
using Entities.Dto.ShoppingCart;
using Entities.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

            await _cartItemService.CreateCartItem( cartItem );

            await UpdateShoppingCart( cartItem.ShoppingCartId );

            _logger.LogInfo( "Se ha agregado un nuevo item en el shop correctamete." );
        }

        public async Task DeleteProductInCart(int shopCartId, int itemCartId ) {
            await _cartItemService.DeleteItemCart( itemCartId );

            await UpdateShoppingCart( shopCartId );

            _logger.LogInfo( "Se ha eliminado un item en el shop correctamete." );
        }
        private async Task<ShoppingCart> GetShoppingCart( int shopCartId ) {
            var cartItems = await _repository.ShoppingCart.GetShoppingCartByIdAsync( shopCartId ); 

            IsNull( cartItems, $"No se ha podido obtener el Shopping cart para el id: {shopCartId}" );

            _logger.LogInfo( $"Se ha obtendio el shopping cart de id: {shopCartId}" );

            return cartItems;
        }

        private async Task<float> CalculateTotal( IEnumerable<CartItem> cartItems ) { 
            var total = 0.0f;

            foreach( var item in cartItems ) {
                total += item.TotalPrice;
            }

            return total;
        }

        private async Task UpdateShoppingCart(int shopCartId) {

            var shopCart = await GetShoppingCart( shopCartId );

            shopCart.Total = await CalculateTotal( shopCart.CartItems );

            _repository.ShoppingCart.UpdateShopCart( shopCart );
            await _repository.SaveAsync();


        }
        private async Task SetShoppingCartInUser(User user ) {
            var shoppingCart = await _repository.ShoppingCart.GetShoppingCartByUserAsync( user.Id );

            User userUpdate = user;
            userUpdate.Id = shoppingCart.Id;
            _repository.User.UpdateUser( userUpdate );
            await _repository.SaveAsync();
        }


    }
}
