using AutoMapper;
using Azure;
using Entities.Dto.Category;
using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using Entities.Validators;
using FluentValidation;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : BaseService {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        
        public CategoryService( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper ) : base(logger) {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<PagedList<Category>> GetAll(CategoryParameters parameters) {
            var categories = await _repository.Category.GetAllAsync(parameters);
            IsNull( categories, "No se han podido obtener todas las categorias." );

            _logger.LogInfo( $"Se han obtenido {categories.Count()} categorias." );
            return categories;
        }

        public IEnumerable<CategoryDto> ConvertInDto( PagedList<Category> category) {
            return _mapper.Map<IEnumerable<CategoryDto>>( category );
        }

        public async Task<CategoryDto> GetById( int id ) {
            var category = await _repository.Category.GetByIdAsync( id );

            IsNull( category, $"No se encuantra la categoria de id: {id}" );
            
            _logger.LogInfo( $"Se ha retornado correctamente la categoria {category.Name}" );

            var result = _mapper.Map<CategoryDto>( category );
            return result;
        }
        public async Task<CategoryDto> Create( CategoryCreateDto categoryDto ) {

            IsNull( categoryDto, "No hay datos ingresados para crear una categoria." );

            var category = _mapper.Map<Category>( categoryDto );

            Validate( category );

            _repository.Category.CreateCategory( category );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha creado correctamente la categoria {categoryDto.Name}" );

            
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task Update( CategoryUpdateDto categoryDto ) {

            IsNull( categoryDto, "No hay datos ingresados para actualizar la categoria." );

            var category = _mapper.Map<Category>( categoryDto );
            _repository.Category.UpdateCategory( category );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha actualizado correctamente la categoria {categoryDto.Name}" );
        }

        public async Task Delete( int id ) {
            var category = await _repository.Category.GetByIdAsync( id );

            IsNull(category, $"No se encuantra la categoria de id:{id}" );

            _repository.Category.DeleteCategory( category );
            await _repository.SaveAsync();
        }
        private void Validate(Category category ) {

            CategoryValidator validator = new( category );

            if( !validator.IsValid() ) {
                _logger.LogError( "Los datos son invalidos." );
                validator.ValidateAndThrow( category );
            }
        }
    }
}
