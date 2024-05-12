using AutoMapper;
using Entities.Dto.CartItem;
using Entities.Dto.Category;
using Entities.Dto.Comment;
using Entities.Dto.Images;
using Entities.Dto.Products;
using Entities.Dto.ShoppingCart;
using Entities.Dto.User;
using Entities.Model;

namespace E_Commerce.Shared
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {


            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            ;
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            #endregion

            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            #endregion

            #region Comment 
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<CommentCreateDto, Comment>();
            #endregion

            #region Image
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<ImageCreateDto, Image>();
            CreateMap<ImageUpdateDto, Image>();
            #endregion

            #region ShoppingCart
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
            CreateMap<ShoppingCartUpdateDto, ShoppingCart>();
            #endregion

            #region CartItem
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<CartItemCreationDto, CartItem>();
            CreateMap<CartItemUpdateDto, CartItem>();
            #endregion

            #region User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreationDto, User>();
            #endregion
        }
    }
}
