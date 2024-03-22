using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Signal.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ChatController : ControllerBase
    {
        public static Dictionary<int, string> Rooms =
            new Dictionary<int, string>() { { 1, "Cervezas" }, { 2, "Programacion" }, { 3, "Moda" } };

    }
}
