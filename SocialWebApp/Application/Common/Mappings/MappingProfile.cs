using Application.Posts.Queries;
using Application.Posts.Queries.GetPersonalPosts;
using Application.Users.Queries.Login;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserInfo;
using AutoMapper;
using Domain.Entities;
using Application.Photos.Queries.GetPhotoByUserQuery;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
 
  
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<NewUserDto, User>();
            CreateMap<User, NewUserVm>();
            CreateMap<User, LoginUserDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Photo, PhotoDto>();

            
        }
}