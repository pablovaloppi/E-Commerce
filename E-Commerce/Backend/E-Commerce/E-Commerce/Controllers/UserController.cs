using Entities.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace E_Commerce.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly UserService _userService;

        public UserController( UserService userService ) {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(UserCreationDto userCreation ) {
            var user = await _userService.CreateNewUser( userCreation );

            if(user is null ) {
                return BadRequest( _userService.ResponseError( "El Usuario ya se encuentra registrado." ));
            }

            return Ok( _userService.ResponseCreate(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id ) {
            await _userService.Delete( id );

            return Ok( _userService.ResponseDelete( id ) );
        }
    }
}
