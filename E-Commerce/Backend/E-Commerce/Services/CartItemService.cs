using AutoMapper;
using Entities.Dto.CartItem;
using Entities.Dto.Products;
using Entities.Helpers;
using Entities.Model;
using Entities.Validators;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Services
{
    public class CartItemService : BaseService<CartItem> {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CartItemService( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper ) :base(logger){
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            SetValidator( new CartItemValidator() );
        }

        public async Task CreateCartItem( CartItemCreationDto cartItem ) {
            IsNull( cartItem, "El CartItem es null." );

            var result = _mapper.Map<CartItem>( cartItem );

            Validate( result );

            var totalPrice = await CalculateTotalPrice( result );
            result.TotalPrice = totalPrice;

            _repository.CartItem.CreateItem( result );

            await _repository.SaveAsync();

            _logger.LogInfo( "Se ha creado el CartItem correctamente." );
        }

        public async Task DeleteItemCart( int itemCartId ) {
            var itemCart = await _repository.CartItem.GetCartItemByIdAsync( itemCartId );

            IsNull( itemCart, $"No se ha podido obtener el ItemCart de id: {itemCartId}." );

            _logger.LogInfo( $"Se han obtenido CartItem de id :{itemCartId}. " );

            _repository.CartItem.DeleteCartItem( itemCart );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha eliminado el CartItem de id: {itemCart} correctamente." );

        }
        public async Task<IEnumerable<CartItemDto>> GetCartItemsById(int shopCartId ){
            var cartItems = await _repository.CartItem.getAllByShopCartIdAsync( shopCartId );

            isEmpty( cartItems, "No se ha obtenido ningun CartItem" );

            _logger.LogInfo( $"Se han obtenido {cartItems.Count()} CartItems. " );

            return _mapper.Map<IEnumerable<CartItemDto>>(cartItems);
        }

        private async Task<float> CalculateTotalPrice(CartItem cartItem ) {
            var product = await _repository.Product.GetByIdAsync( cartItem.ProductId );

            IsNull( product, $"No se ha podido obtener el producto con el id: {cartItem.ProductId} administrado por cartItem." );

            return cartItem.Quantity * product.Price;
        }
    }
}
