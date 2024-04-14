using AutoMapper;
using Entities.Dto.Category;
using Entities.Dto.Products;
using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using Entities.Validators;
using Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Services
{
    public class ProductService : BaseService<Product>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public string roles = "Administrador, Moderador, Vendedor";
        public ProductService(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper): base(logger) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            SetValidator( new ProductValidator() );
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(ProductParameters parameters, HttpResponse responseController) {
            var products = await _repository.Product.GetAllAsync(parameters);

            IsNull( products, "No hay productos en la base de datos" );

            _logger.LogInfo( $"Se han obtenido {products.Count()} productos." );

            AddMetadata( products, responseController );

            return ConvertInDto(products);
        }
        
        public async Task<ProductDto> GetById(int id ) {
            var product = await _repository.Product.GetByIdAsync( id );

            IsNull( product, $"No se ha podido encontrar ningun producto con el id: {id}" );

            _logger.LogInfo( $"Se ha obtendio el producto de id: {id} correctamente." );

            return _mapper.Map<ProductDto>( product );
        }

        public async Task<ProductDto> Create(ProductCreateDto productCreate ) {
            IsNull( productCreate, "Los datos ingresados estan vacios o son incorrectos." );

            var product = _mapper.Map<Product>( productCreate );

            Validate( product );

            _repository.Product.CreateProduct( product );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha creado correctamente la categoria {product.Title}" );

            return _mapper.Map<ProductDto>( product );
        }
      
        public async Task Update(int id, ProductUpdateDto productUpdate ) {
            var product = await _repository.Product.GetByIdAsync( id );

            IsNull( product, $"No se ha podido encontrar ningun producto con el id: {id}" );

            IsNull( productUpdate, "No hay datos ingresados para actualizar la categoria." );

            var result = _mapper.Map<Product>( productUpdate );

            Validate( product );

            result.Id = id;
            _repository.Product.UpdateProduct( result );;
            await _repository.SaveAsync();

            _logger.LogInfo( $"El producto {product.Title} y de id: {product.Id} se ha actualizado correctamente." );

        }

        public async Task Delete(int id ) {
            var product = await _repository.Product.GetByIdAsync( id );

            IsNull( product );

            _repository.Product.DeleteProduct(product);
            await _repository.SaveAsync();

            _logger.LogInfo( $"El producto de id: {product.Id} se ha eliminado correctamente." );
        }

        public IEnumerable<ProductDto> ConvertInDto( PagedList<Product> products ) {
            return _mapper.Map<IEnumerable<ProductDto>>( products );
        }

    }

}
