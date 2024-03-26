using Entities.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ECommerceDbContext _eCommerceDbContext;
        private ICategoryRepository _category;
        private ICommentRepository _comment;
        private IImageRepository _image;
        private IProductRepository _product;
        private ISaleRepository _sale;
        private ISellerRepository _seller;
        private IUserRepository _user;
        private IUserTypeRepository _userType;

        public RepositoryWrapper( ECommerceDbContext eCommerceDbContext ) {
            _eCommerceDbContext = eCommerceDbContext;
        }

        public ICategoryRepository Category {
            get {
                if( _category is null ) {
                    _category = new CategoryRepository(_eCommerceDbContext);
                }
                return _category;
            }
        }

        public ICommentRepository Comment {
            get {
                if( _comment is null ) {
                    _comment = new CommentRepository( _eCommerceDbContext );
                }
                return _comment;
            }
        }

        public IImageRepository Image {
            get {
                if( _image is null ) {
                    _image = new ImageRepository( _eCommerceDbContext );
                }
                return _image;
            }
        }

        public IProductRepository Product {
            get {
                if( _product is null ) {
                    _product = new ProductRepository( _eCommerceDbContext );
                }
                return _product;
            }
        }

        public ISaleRepository Sale {
            get {
                if( _sale is null ) {
                    _sale = new SaleRepository( _eCommerceDbContext );
                }
                return _sale;
            }
        }

        public ISellerRepository Seller {
            get {
                if( _seller is null ) {
                    _seller = new SellerRepository( _eCommerceDbContext );
                }
                return _seller;
            }
        }

        public IUserRepository User {
            get {
                if( _user is null ) {
                    _user = new UserRepository( _eCommerceDbContext );
                }
                return _user;
            }
        }
        public IUserTypeRepository UserType {
            get {
                if( _userType is null ) {
                    _userType = new UserTypeRepository( _eCommerceDbContext );
                }
                return _userType;
            }
        }

        public async Task SaveAsync() {
            await _eCommerceDbContext.SaveChangesAsync();
        }
    }
}
