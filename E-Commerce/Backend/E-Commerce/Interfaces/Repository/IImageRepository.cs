using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> GetByIdAsync(int id);
        Task<IEnumerable<Image>> GetAllByIdProductAsync( int productId );
        void CreateImage(Image image);
        IEnumerable<Image> CreateImagesProducts(IEnumerable<string> imagesName, int productId);
        void UpdateImage(Image image);
        void DeleteImage(Image image);
    }
}
