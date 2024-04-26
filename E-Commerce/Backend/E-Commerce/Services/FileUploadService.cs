using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public enum FileType {
        IMAGE,
        PDF,
        EXEL,
        NONE
    }
    public class FileUploadService : BaseService<object> {
        private const string FOLDER_RESOURCES = "Resources";
        private const string FOLDER_IMAGES = "Images";
        private const string FOLDER_DOCUMENTS = "Documents";

        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;

        public FileUploadService( ILoggerManager logger, IConfiguration configuration ) : base( logger ) {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IEnumerable<string>> Upload( HttpRequest request ) {
            List<string> fileList = new();

            IsNull( request.Form, "No se a enviado ningun archivo." );

            var form = await request.ReadFormAsync();
            var files = form.Files;

            isEmpty( files, "No se ha obtenido ningun archivo." );

            foreach( var file in files ) {
                fileList.Add( await SetFile( file ));
            }

            return fileList;
        }

        private async Task<string> SetFile( IFormFile file ) {

            var fileResult = "";
            switch( GetFileType( file ) ) {
                case FileType.IMAGE:
                    fileResult = await CreateFileAsync( file, FOLDER_IMAGES );
                    break;
                case FileType.PDF:
                    fileResult = await CreateFileAsync( file, FOLDER_DOCUMENTS );
                    break;

                case FileType.NONE:

                    break;
            }

            return fileResult;
        }
        private async Task<string> CreateFileAsync( IFormFile file, string folderInResource ) {
            var fileName = file.FileName.ToString();

            var folderName = Path.Combine( FOLDER_RESOURCES, folderInResource );
            var pathToSave = Path.Combine( Directory.GetCurrentDirectory(), folderName );

            
            var fullPath = Path.Combine( pathToSave, fileName );
            var dbPath = Path.Combine( folderName, fileName );

            var stream = new FileStream( fullPath, FileMode.Create );

            await file.CopyToAsync(stream );

            _logger.LogInfo( $"Se creo el archivo {fileName} en la direccion {pathToSave} correctamente." );

            return Path.Combine( _configuration.GetSection( "Jwt:Issuer" ).Value, dbPath);
        }

        private FileType GetFileType(IFormFile file){
            var type = file.ContentType.Split( '/' )[ 1 ];

            if( IsImage( type ) )
                return FileType.IMAGE;
            else if( IsPdf( type ) )
                return FileType.PDF;

            return FileType.NONE;

        }

        private bool IsImage(string type ) {
            Regex regex = new Regex( "(jpg|jpeg|pjpeg|jfif|pjp|png)" );
            if( !regex.IsMatch( type ) ) {
                return false;
            }
            return true;
        }

        private bool IsPdf(string type ) {
            Regex regex = new Regex( "(pdf)" );
            if( !regex.IsMatch( type ) ) {
                return false;
            }
            return true;
        }
        
    }
}
