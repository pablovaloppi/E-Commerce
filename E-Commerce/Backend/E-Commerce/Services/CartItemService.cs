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

        public CartItemService( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper ) : base( logger ) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            SetValidator( new CartItemValidator() );
        }

        public async Task CreateCartItem( CartItemCreationDto cartItem ) {
            IsNull( cartItem, "El CartItem es null." );

            var result = _mapper.Map<CartItem>( cartItem );

            Validate( result );

            var product = await _repository.Product.GetByIdAsync( cartItem.ProductId );

            IsNull( product, $"No se ha podido obtener el producto con el id: {cartItem.ProductId} administrado por cartItem." );

            result.Quantity = GetQuantityInRange( result.Quantity, product.Amount );
            result.TotalPrice = CalculateTotalPrice( result.Quantity, product.Price );

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

        public async Task DeleteAllItemCartByShopCartId(IEnumerable<CartItem> cartItems ) {
            IsNull( cartItems, "No se a pasado ninguna lista de cartItem" );

            _repository.CartItem.DeleteCartItemRange( cartItems );
            await _repository.SaveAsync();

            _logger.LogInfo( "Se han borrado todos los cartItems" );
        }
        public async Task UpdateQuantityCartItem( CartItemCreationDto cartItem ) {
            if( cartItem.Id is null) {
                return;
            }

            var item = await _repository.CartItem.GetCartItemByIdAsync( (Int32)cartItem.Id );

            item.Quantity += cartItem.Quantity;

            _repository.CartItem.UpdateItem( item );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha actualizado el cartItem de id: {item.Id} correctamente." );
        }

        public async Task<bool> ThereIsStock(CartItemCreationDto cartItem, int quantityInShop) {
            var product = await _repository.Product.GetByIdAsync( cartItem.ProductId );

            return product.Amount >= cartItem.Quantity + quantityInShop;
        }               

        public async Task UpdateTotalPriceItems( int shoppinCartId ) {
            var cartItems = await _repository.CartItem.getAllByShopCartIdAsync( shoppinCartId );

            cartItems.ToList().ForEach( item => item.TotalPrice = CalculateTotalPrice( item.Quantity, item.Product.Price ) );
            _repository.CartItem.UpdateItemRange( cartItems );
            await _repository.SaveAsync();
        }

        private float CalculateTotalPrice(float quantity, float price ) {
            return quantity * price;
        }

        private int GetQuantityInRange( int quantity, int amount  ) {
            return amount > quantity ? quantity : amount;
        }
    }
}
