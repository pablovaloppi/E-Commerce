using Entities.Helpers;
using Entities.Model;
using Entities.Responses;
using Entities.Validators;
using FluentValidation;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public abstract class BaseService<T> {
        private readonly ILoggerManager _logger;
        private ICustomValidator<T> _validator;
        private string _typeNameEntity;

        public BaseService( ILoggerManager logger ) {
            _logger = logger;
            // example: ->     Entites.Model.Category  -> category
            if( typeof( T ) != typeof( object ) ) {
                var splited = typeof( T ).ToString().Split( "." );
                _typeNameEntity = splited[ splited.Length - 1 ].ToLower();
            }

        }

        protected void IsNull( object entity, string message = null ) {
            if( entity is null ) {
                _logger.LogError( message is null ? "Los datos son nulos." : message );
                throw new Exception( message is null ? "Los datos son nulos." : message );
            }
        }
        protected void isEmpty( IEnumerable<object> values, string message ) {
            if( values.Count() == 0 ) {
                _logger.LogError( message is null ? "No hay nigun dato." : message );
                throw new Exception( message is null ? "No hay nigun dato." : message );
            }
        }
        protected void SetValidator( ICustomValidator<T> validator ) {
            _validator = validator;
        }
        protected void Validate( T entity ) {
            _validator.SetEntity( entity );
            if( !_validator.IsValid() ) {
                _logger.LogError( "Los datos son invalidos." );
                throw new ValidationException( _validator.ErrorMessages() );
            }

            _logger.LogInfo( "Los datos se han validado correctamente." );
        }

        public Response ResponseGetById( int id, object data ) {

            return new Response( 200, $"Se han obtenido el/la  {_typeNameEntity} de id:{id}.", data );
        }
        public Response ResponseGetAll( int count, object data ) {
            return new Response( 200, $"Se han obtenido {count} {_typeNameEntity}'s.", data );
        }
        public Response ResponseCreate( object data ) {
            return new Response( 201, $"Se ha creado un/a {_typeNameEntity} correctamente.", data );
        }
        public Response ResponseUpdate( int id ) {
            return new Response( 202, $"Se ha actualido el/la {_typeNameEntity} de id: {id} correctamente." );
        }
        public Response ResponseDelete( int id ) {
            return new Response( 202, $"Se ha eliminado el/la {_typeNameEntity} de id: {id} correctamente." );
        }
        public Response ResponseError( string message ) {
            return new Response( 400, message, null );
        }

        protected void AddMetadata( PagedList<T> entity, HttpResponse responseController ) {
            var metadata = new {
                entity.TotalCount,
                entity.PageSize,
                entity.CurrentPage,
                entity.TotalPages,
                entity.HasNext,
                entity.HasPrevious
            };
            responseController.Headers.Add( "X-Pagination", JsonConvert.SerializeObject( metadata ) );
        }
    }
}
