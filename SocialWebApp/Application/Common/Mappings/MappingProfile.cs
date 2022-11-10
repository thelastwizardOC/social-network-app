using Application.Post.Queries.GetPersonalPosts;
using Application.User.Queries.GetUserInfo;
using AutoMapper;

namespace Application.Common.Mappings;

public class MappingProfile:Profile
{
        public MappingProfile()
        {
            CreateMap<SocialWebApp.Models.Post, PersonalPostDto>();
            CreateMap<SocialWebApp.Models.User, UserDto>();
        }
}