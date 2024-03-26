using E_Commerce.CustomExceptionMiddleware.CustomExceptions;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get() {
            //var result = ;

            return Ok( await _categoryService.GetAll() );
        }
    }
}
