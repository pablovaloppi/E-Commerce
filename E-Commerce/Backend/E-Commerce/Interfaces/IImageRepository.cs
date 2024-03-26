using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> GetByIdAsync( int id );
        void CreateImage(Image image);
        void UpdateImage(Image image);
        void DeleteImage( Image image );
    }
}
