using Application.Posts.Queries.GetPersonalPosts;
using Application.Users.Queries.Login;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserInfo;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Post, PersonalPostDto>();
    CreateMap<User, LoginUserDto>();
    CreateMap<User, UserDto>();
    CreateMap<NewUserDto, User>();
    CreateMap<User, NewUserVm>();
  }
}