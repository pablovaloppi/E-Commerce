using AutoMapper;
using Entities.Dto.Category;
using Entities.Dto.Comment;
using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : BaseService<Comment>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CommentService( IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger) : base( logger ) {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedList<CommentDto>> GetByProduct(CommentParameters parameters, int productId ) {
            var comment =  await _repository.Comment.GetAllByProductAsync( parameters, productId );

            IsNull( comment, $"No se han podido obtener todas los comentarios del producto id: {productId}." );

            _logger.LogInfo( $"Se han obtenido {comment.Count} comentarios del producto de id: {productId}." );

            var result = _mapper.Map<PagedList<CommentDto>>( comment );
            return result;
        }

        public async Task<PagedList<CommentDto>> GetByUser( CommentParameters parameters, int userId ) {
            var comment = await _repository.Comment.GetAllByUserAsync( parameters, userId );

            IsNull( comment, $"No se han podido obtener todas los comentarios del usuario id: {userId}." );

            _logger.LogInfo( $"Se han obtenido {comment.Count} comentarios del usuario de id: {userId}." );

            var result = _mapper.Map<PagedList<CommentDto>>( comment );
            return result;
        }
    
        public async Task<CommentDto> Create(CommentCreateDto commentDto ) {
            IsNull( commentDto, "No hay datos ingresados para crear un comentario." );

            var comment = _mapper.Map<Comment>( commentDto );

            comment.Date = DateTime.Now; 

            _repository.Comment.CreateComment( comment );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha creado correctamente el comentario {comment.Id}" );

            return _mapper.Map<CommentDto>( comment );
        }
        
        public async Task Delete(int id ) {
            var comment = await  _repository.Comment.GetByIdAsync( id );

            IsNull( comment, $"No se ha podido obtener el comentarios de id: {id}." );

            _repository.Comment.DeleteComment( comment );
            await _repository.SaveAsync();

            _logger.LogInfo( $"Se ha eliminado el comentario correctamente." );
        }
    }
}
