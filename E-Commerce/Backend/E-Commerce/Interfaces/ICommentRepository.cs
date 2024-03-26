using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<IEnumerable<Comment>> GetAllByProductAsync( int productId );
        Task<IEnumerable<Comment>> GetAllByUserAsync( int userId );
        void CreateComment( Comment comment );
        void UpdateComment( Comment comment );
        void DeleteComment( Comment comment );

    }
}
