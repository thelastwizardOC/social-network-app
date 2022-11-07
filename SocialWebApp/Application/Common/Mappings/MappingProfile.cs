using Application.Post.Queries.GetPersonalPosts;
using AutoMapper;

namespace Application.Common.Mappings;

public class MappingProfile:Profile
{
        public MappingProfile()
        {
            CreateMap<SocialWebApp.Models.Post, PersonalPostDto>();
        }
}