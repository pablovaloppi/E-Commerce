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
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateImage( Image image ) {
            Create( image );
        }

        public void DeleteImage( Image image ) {
            Delete( image );
        }

        public async Task<IEnumerable<Image>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<Image> GetByIdAsync( int id ) {
            return await FindByCondition( image => image.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateImage( Image image ) {
            Update(image);
        }
    }
}
