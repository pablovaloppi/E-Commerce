using Entities.Model;
using Interfaces.Repository;
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
        private readonly ECommerceDbContext _eCommerceDbContext;

        public ImageRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
            _eCommerceDbContext = eCommerceDbContext;
        }

        public void CreateImage( Image image ) {
            Create( image );
        }
        public IEnumerable<Image> CreateImagesProducts( IEnumerable<string> imagesName, int productId ) {
            var imageList = new List<Image>();
            foreach ( var image in imagesName ) {
                var img = new Image() { Name = image, ProductId = productId };

                Create( img );

                imageList.Add( img );
            }

            return imageList;
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

        public async Task<IEnumerable<Image>> GetAllByIdProductAsync(int productId) {
            return await FindByCondition( image => image.ProductId == productId ).ToListAsync();
        }

        public void UpdateImage( Image image ) {
            Update(image);
        }

    }
}
