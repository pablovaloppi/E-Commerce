using AutoMapper;
using Entities.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleService : BaseService<Sale> {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly ProductService _productService;

        public SaleService( IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger, ShoppingCartService shoppingCartService, ProductService productService ) : base( logger ) {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }

        public async Task CreateNewSale( int idShoppingCart ) {
            var shopCart = await _repository.ShoppingCart.GetShoppingCartByIdAsync( idShoppingCart );

            IsNull( shopCart, "No se han podido obtener los articulos del shopCart." );
            //TODO: Falta revisar si realmente hay esa cantidad de productos en este momento
            // Puede existir el caso que 2 usuarios tenian en el carrito el mismo producto y uno compra antes que el otro
            // Los carritos no se habian actualizado y por lo tanto se venderian productos que no hay en stock
            await _repository.SetTransaction();

                _repository.Sale.CreateSale( new Sale { UserId = shopCart.UserId, TotalAmount = shopCart.Total, SaleDate = DateTime.Now } );
                await _repository.SaveAsync();

                _logger.LogInfo( " Se ha creado una nueva Sale correctamente." );

                var sale = await _repository.Sale.GetLastByUserIdAsync( shopCart.UserId );

                await CreateProductsSale( sale.Id, shopCart.CartItems );


            await _productService.UpdateAmountRange( shopCart.CartItems.Select( items => items.Quantity ).ToList(),
                                                 shopCart.CartItems.Select( items => items.Product ).ToList() );


            await _shoppingCartService.DeleteAllProductsInCart( shopCart.Id );

            await _repository.CommitTransaction();

        }

        private async Task CreateProductsSale( int idSale, IEnumerable<CartItem> cartItems ) {
            IsNull( cartItems, "No se han obtenido items del shopCart." );

            _repository.ProductSale.CreateProductSaleRange( MapProductSales( idSale, cartItems ) );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se han creado los productSales correactamente para la venta de id: {idSale}." );
        }
        private IEnumerable<ProductSale> MapProductSales( int idSale, IEnumerable<CartItem> cartItems ) {
            List<ProductSale> listResult = new();

            foreach ( var cartItem in cartItems ) {
                listResult.Add( MapProductSale( idSale, cartItem ));
            }

            return listResult;
        }

        private ProductSale MapProductSale( int idSale, CartItem cartItem ) {
            return new ProductSale {
                ProductId = cartItem.ProductId,
                ProductQuantity = cartItem.Quantity,
                SaleId = idSale
            };
        }
    }
}
// Procesar pago
// agregar nueva venta
    //tomo los datos desde el id del shoppingCart que hay en ese momento
        // Hay esos productos en este momento?
            //Transformo los cartitems en productSales
            //creo nueva venta
        
        // Borro el shoppingCart
        // Descuento los items vendidos del stock del producto vendido
        // devuelvo si se genero la venta correctamente