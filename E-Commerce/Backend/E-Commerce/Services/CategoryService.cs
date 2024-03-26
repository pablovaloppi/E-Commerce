using Entities.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;

        public CategoryService( IRepositoryWrapper repository, ILoggerManager logger) {
            this._repository = repository;
            this._logger = logger;
        }

        public Task<IEnumerable<Category>> GetAll() {
            var categories = _repository.Category.GetAllAsync();
            if( categories is null ) {
                _logger.LogError( "No se han podido obtener todas las categorias." );
            }

            _logger.LogInfo( "Se han obtenido todas las categorias." );

            return categories;
        }
    }
}
