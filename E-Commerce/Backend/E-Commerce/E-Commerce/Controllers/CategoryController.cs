using E_Commerce.CustomExceptionMiddleware.CustomExceptions;
using E_Commerce.Responses;
using Entities.Dto.Category;
using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using Interfaces;
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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController( CategoryService categoryService ) {
            this._categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CategoryParameters parameters) {
            var categories = await _categoryService.GetAll( parameters );

            AddMetadata( categories );

            var result = _categoryService.ConvertInDto( categories );

            return Ok( new Response(200, $"Se han obtenido {result.Count()} categorias.", result ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id ) {
            var result = await _categoryService.GetById( id );
            return Ok( new Response( 200, $"Se ha obtenido la categoria correctamente.", result ) );
        }

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CategoryCreateDto category) {
            var result = await _categoryService.Create( category );
            return Ok(new Response( 201, $"Se ha creado la categoria correctamente.", result ) );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id ) {
            await _categoryService.Delete( id );
            return Ok( new Response(204, "Se ha eliminado la categoria correctamente."));
        }

        private void AddMetadata(PagedList<Category> categories) {
            var metadata = new {
                categories.TotalCount,
                categories.PageSize,
                categories.CurrentPage,
                categories.TotalPages,
                categories.HasNext,
                categories.HasPrevious
            };
            Response.Headers.Add( "X-Pagination", JsonConvert.SerializeObject( metadata ) );
        }
    }
}
