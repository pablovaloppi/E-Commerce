using Entities.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace E_Commerce.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class SaleController : ControllerBase {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService) {
            _saleService = saleService;
        }

        [HttpGet( "{shopCartId}" )]
        public async Task<IActionResult> NewSale( int shopCartId ) {
            await _saleService.CreateNewSale( shopCartId );

            return Ok( new Response { StatusCode = 201, Data = null, Message="Se ha concreatdo la venta correctamente." } );
        }
    }
}

