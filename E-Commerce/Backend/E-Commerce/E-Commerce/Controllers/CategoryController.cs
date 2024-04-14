using E_Commerce.CustomExceptionMiddleware.CustomExceptions;
using Entities.Dto.Category;
using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
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
            var categories = await _categoryService.GetAll( parameters, Response );

            return Ok( _categoryService.ResponseGetAll( categories.Count(), categories ) );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id ) {
            var result = await _categoryService.GetById( id );
            return Ok( _categoryService.ResponseGetById(id, result) );
        }

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CategoryCreateDto category) {
            var result = await _categoryService.Create( category );
            return Ok(_categoryService.ResponseCreate( result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id ) {
            await _categoryService.Delete( id );
            return Ok(_categoryService.ResponseDelete(id));
        }

  
    }
}
