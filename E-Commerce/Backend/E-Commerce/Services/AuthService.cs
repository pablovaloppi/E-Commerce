using Entities.Dto.User;
using Entities.Model;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService : BaseService<Auth> {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthService( IRepositoryWrapper repository, ILoggerManager logger, IConfiguration configuration) : base( logger ) {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> HasLogued( UserLoginDto userLogin ) {
            _user = await _repository.User.GetByUserNameAsync( userLogin.UserName );
            IsNull( _user, $"No se encuentra el usuario: {userLogin.UserName} " );

            if( !VerifyPassword( _user, userLogin ) ) {
                _logger.LogError( "El password es incorrecto" );
                return false;
            }

            _logger.LogInfo( $"El usuario{userLogin.UserName} se ha logueado correctamente." );
            return true;
        }

        public Auth InfoUser() {
            if( _user is null) {
                return null;
            }
            return new Auth { Id = _user.Id, ShoppingCartId = _user.ShoppingCartId, UserName = _user.UserName, UserTypeId = _user.UserTypeId, Token = GenerateToken() };
        }

        private  string GenerateToken() {
            var secretKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration.GetSection( "Jwt:Key" ).Value! ));
            var signinCredentials = new SigningCredentials( secretKey, SecurityAlgorithms.HmacSha256 );

            var userRole =  _repository.User.GetRoleUser( _user );
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role, userRole)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.GetSection( "Jwt:Issuer" ).Value,
                audience: _configuration.GetSection( "Jwt:Audience" ).Value,
                claims: claims,
                expires: DateTime.Now.AddSeconds( Double.Parse( _configuration.GetSection( "Jwt:Expires" ).Value! ) ),
                signingCredentials: signinCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken( tokenOptions );
        }
        private bool VerifyPassword( User user, UserLoginDto userLogin ) {
            return String.Equals( user.Password, userLogin.Password, StringComparison.Ordinal);
        }
    }
}
