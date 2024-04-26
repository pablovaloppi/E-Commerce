using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Services;
using System.Net.Mime;

namespace E_Commerce.Controllers
{
    [Route( "api/upload" )]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly FileUploadService _fileUploadService;

        public FileUploadController(FileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }
        [HttpPost]
        public async Task<IActionResult> Upload() {
            await _fileUploadService.Upload( Request );

            return Ok();
        }
    }
}
