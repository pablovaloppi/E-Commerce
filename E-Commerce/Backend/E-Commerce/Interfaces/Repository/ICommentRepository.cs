using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface ICommentRepository
    {
        Task<PagedList<Comment>> GetAllAsync( CommentParameters parameters );
        Task<Comment> GetByIdAsync( int id );
        Task<PagedList<Comment>> GetAllByProductAsync( CommentParameters parameters, int productId);
        Task<PagedList<Comment>> GetAllByUserAsync( CommentParameters parameters, int userId );
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);

    }
}
