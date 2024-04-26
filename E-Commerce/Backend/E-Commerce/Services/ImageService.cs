using AutoMapper;
using Entities.Dto.Images;
using Entities.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : BaseService<Image>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ImageService(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger) : base(logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Create(ImageCreateDto imageCreation) {
            IsNull( imageCreation, "Los datos enviados estan vacios." );

            var image = _mapper.Map<Image>( imageCreation );

            Validate( image );

            _repository.Image.CreateImage( image  );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha creado correctamente la imagen: {image.Name} " );
        }

        public async Task<IEnumerable<ImageDto>> GetAllByIdProductAsync(int id ) {
            var images = await _repository.Image.GetAllByIdProductAsync( id );

            isEmpty( images, "No se ha obtenido ninguna imagen." );

            _logger.LogInfo( $"Se han obtenido {images.Count()} imagenes." );

            return _mapper.Map<IEnumerable<ImageDto>> ( images );
        }
       
        
    }
}
