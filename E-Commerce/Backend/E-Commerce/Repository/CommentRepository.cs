using Entities.Model;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateComment( Comment comment ) {
            Create( comment );
        }

        public void DeleteComment( Comment comment ) {
            Delete(comment );
        }

        public async Task<IEnumerable<Comment>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByProductAsync( int productId ) {
            return await FindByCondition( comments => comments.ProductId == productId ).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByUserAsync( int userId ) {
            return await FindByCondition( comments => comments.UserId == userId ).ToListAsync();
        }

        public void UpdateComment( Comment comment ) {
            Update( comment );
        }
    }
}
