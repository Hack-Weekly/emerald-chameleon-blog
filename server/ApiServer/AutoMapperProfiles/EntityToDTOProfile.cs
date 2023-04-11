using ApiServer.DTO.BlogPostComments;
using ApiServer.DTO.BlogPostLikes;
using ApiServer.DTO.BlogPosts;
using ApiServer.DTO.Users;
using ApiServer.DTO.WeatherForecast;
using ApiServer.Model;
using AutoMapper;
using System.Runtime.InteropServices;

namespace ApiServer.AutoMapperProfiles
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        { 
            //GET mappings
            CreateMap<WeatherForecast, GetWeatherForecastDTO>().ReverseMap();
            CreateMap<User, GetUsersDTO>().ReverseMap();
            CreateMap<BlogPost, GetBlogPostDTO>().ReverseMap();
            CreateMap<BlogPostComment, GetBlogPostCommentDTO>().ReverseMap();
            CreateMap<BlogPostLike, GetBlogPostLikeDTO>().ReverseMap();



            //CREATE mappings
            CreateMap<WeatherForecast, CreateWeatherForecastDTO>().ReverseMap();
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<BlogPost, CreateBlogPostDTO>().MaxDepth(1).ReverseMap();
            CreateMap<BlogPostComment, CreateBlogPostCommentDTO>().ReverseMap();
            CreateMap<BlogPostLike, CreateBlogPostLikeDTO>().ReverseMap();

            //UPDATE mappings
            CreateMap<BlogPost, UpdateBlogPostDTO>().ReverseMap();
        }
    }
}
