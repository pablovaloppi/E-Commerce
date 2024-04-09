using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using Interfaces.Repository;
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

        public async Task<Comment> GetByIdAsync( int id ) {
            return await FindByCondition( comment => comment.Id == id ).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Comment>> GetAllAsync( CommentParameters parameters) {
            return await PagedList<Comment>.ToPagedListAsync( Get(), parameters.PageNumber, parameters.PageSize );
        }

        public async Task<PagedList<Comment>> GetAllByProductAsync( CommentParameters parameters, int productId ) {
            return await PagedList<Comment>.ToPagedListAsync(
                FindByCondition( comments => comments.ProductId == productId ),
               parameters.PageNumber, parameters.PageSize );
        }

        public async Task<PagedList<Comment>> GetAllByUserAsync( CommentParameters parameters, int userId ) {
            return await PagedList<Comment>.ToPagedListAsync( 
                FindByCondition( comments => comments.UserId == userId ),
                parameters.PageNumber, parameters.PageSize );
        }

        public void UpdateComment( Comment comment ) {
            Update( comment );
        }
    }
}
