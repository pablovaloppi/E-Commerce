using Entities.Model;
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
    public abstract class BaseService
    {
        private ILoggerManager _logger;

        public BaseService(ILoggerManager logger) {
            _logger = logger;
        }

        protected void IsNull( object entity, string message = null ) {
            if( entity is null ) {
                _logger.LogError( message is null ? "Los datos son nulos." : message );
                throw new Exception( message is null ? "Los datos son nulos." : message );
            }
        }



    }
}
