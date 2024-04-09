using E_Commerce.Responses;
using Entities.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace E_Commerce.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController( AuthService authService) {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLogin ) {
            var result = await _authService.HasLogued( userLogin );

            if( !result ) {
                return BadRequest( new Response {
                    StatusCode = 400,
                    Message = "Usuario o contraseña incorrecta",
                    Data = null
                } );
            }

            return Ok( new Response {
                StatusCode = 200,
                Message = "El usuario se ha logueado correctamente",
                Data = _authService.InfoUser()
            } );
        }
    }
}
