using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UsuarioController : ControllerBase {
        private readonly TestDBContext context;

        public UsuarioController( TestDBContext context ) {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> post( Usuario usuario ) {
            await context.AddAsync( usuario );
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> get() {

            //var usuarios = await context.Usuarios.ToListAsync();

            var cursosUsuarios = context.CursosUsuarios.Where( cu => cu.CursoId == 1 );

            return Ok( cursosUsuarios.Select(cu => cu.Usuario.Name ));
        }
    }
}
