using AutoMapper;
using Entities.Dto.Category;
using Entities.Dto.Comment;
using Entities.Dto.Products;
using Entities.Model;

namespace E_Commerce.Shared
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {


            #region Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            #endregion

            #region Product
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            #endregion

            #region Comment 
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<CommentCreateDto, Comment>();
            #endregion
        }
    }
}
