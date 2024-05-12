using AutoMapper;
using Entities.Dto.User;
using Entities.Model;
using Entities.Validators;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Services
{
    public class UserService : BaseService<User>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ShoppingCartService _shoppingCartService;

        public UserService( IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger, ShoppingCartService shoppingCartService ) : base( logger ) {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            SetValidator( new UserValidator() );
        }

        public async Task<UserDto> CreateNewUser(UserCreationDto newUser) {
            IsNull( newUser, "Los datos enviados estan vacios." );


            var userTest = await _repository.User.GetByUserNameAsync( newUser.UserName );
            if(userTest != null) {
                _logger.LogError( "Ya hay otro usuario con el mismo username." );
                return null;
            }

            await _repository.SetTransaction();
     
            var user = _mapper.Map<User>( newUser );

            Validate( user );

            user.DateOfCreation = DateTime.Now;
            user.PurchaseCount = 0;
            user.UserTypeId = 4; // Usuario comun

            _repository.User.CreateUser( user );
            await _repository.SaveAsync();

            await _shoppingCartService.CreateShoppingCart( user.Id );

            await _repository.CommitTransaction();

            _logger.LogInfo( $"Se ha creado el usiario: {newUser.UserName} correctamente." );

            var result = _mapper.Map<UserDto>(await _repository.User.GetByUserNameAsync( newUser.UserName ));
            

            return result;

        }

        public async Task Delete(int userId ) {
            var user = await _repository.User.GetByIdAsync( userId );

            IsNull( user, $"No se ha encontrado un usuario con el id: {userId}." );

            _repository.User.DeleteUser( user );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha borrado el usuario de id: {userId}." );
        }
    }
}
