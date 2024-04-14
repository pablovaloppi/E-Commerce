using E_Commerce.Responses;
using Entities.Dto.Products;
using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace E_Commerce.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly ProductService _productService;
        public ProductController( ProductService productService ) {
            _productService = productService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get( [FromQuery]ProductParameters parameters) {
            var products = await _productService.GetProducts( parameters, Response );

            return Ok( _productService.ResponseGetAll( products.Count(), products ) );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id ) {
            var product = await _productService.GetById( id );
            return Ok( _productService.ResponseGetById( id, product ) );
        }

        //TODO: Clase heredada de AuthorizeAttribute, IAsyncAuthorizationFilter para poder crear roles personalizados
        // Leidos desde un archivo json o de la db y poder usar algo parecido a [AdministratorAuthorize], [SellerAuthorize]
        [Authorize(Roles = "Administrador, Moderador, Seller")] 
        [HttpPost]
        public async Task<IActionResult> Create( [FromBody]ProductCreateDto product ) {
           var result = await _productService.Create( product );
            return Ok( _productService.ResponseCreate(result) );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, [FromBody]ProductUpdateDto product ) {
            await _productService.Update( id, product );
            return Ok(_productService.ResponseUpdate(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id ) {
            await _productService.Delete( id );
            return Ok(_productService.ResponseDelete(id));
        }
   
    }
}
