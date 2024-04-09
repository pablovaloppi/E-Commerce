using AutoMapper;
using Entities.Dto.Category;
using Entities.Dto.Comment;
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

            #region Comment 
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<CommentCreateDto, Comment>();
            #endregion
        }
    }
}
