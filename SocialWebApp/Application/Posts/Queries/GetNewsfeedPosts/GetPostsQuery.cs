using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts.Queries.GetNewsfeedPosts;


public class GetPostsQuery: IRequest<NewsfeedPostVm>
{
    public int  UserId { get; set; }
    public int Offset { get; set; }          
    public int Limit { get; set; }
}
public class GetPostsQueryHandler:IRequestHandler<GetPostsQuery, NewsfeedPostVm>
{
    private IApplicationDbContext _appDb;
    private readonly IMapper _mapper;

    public GetPostsQueryHandler(IApplicationDbContext appDb,IMapper mapper)
    {
        _appDb = appDb;
        _mapper = mapper;
    }
    
    
    public async Task<NewsfeedPostVm> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts =await  (
            from p in _appDb.Post
            join u in _appDb.User
                on p.User.Id equals u.Id  
            join uf in _appDb.UserFriends
                on p.User.Id equals  uf.FriendId
            where p.User.Id == request.UserId || uf.SourceUserId==request.UserId
            orderby  p.CreatedAt descending 
            select new NewsfeedPostDto()
            {
                Id = p.Id,
                Status = p.Status,
                Photo = p.Photo,
                NumberOfComments = p.NumberOfComments,
                NumberOfLikes = p.NumberOfLikes,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                User = new User()
                {
                    Id = u.Id,
                    FirstName=u.FirstName,
                    LastName=u.LastName,
                    UserName=u.UserName,
                    HashedPassword=u.HashedPassword,
                    Dob=u.Dob,
                    Email=u.Email,
                    Avatar=u.Avatar,
                    Cover=u.Cover,
                    Gender=u.Gender,
                    PhoneNo=u.PhoneNo,
                    CreatedAt=u.CreatedAt,
                    UpdatedAt=u.UpdatedAt
                }
                
            }
        ).Skip(request.Offset).Take(request.Limit).ToListAsync();
            // .OrderByDescending(p=>p.CreatedAt).Skip(request.Offset).Take(request.Limit)/
        List<NewsfeedPostDto> postDtos = _mapper.Map<List<NewsfeedPostDto>>(posts);
        int totalCount = postDtos.Count();
        
        bool hasNextPage = _appDb.Post.Count(p=>p.User.Id==request.UserId) > request.Offset  + request.Limit ;


        return new NewsfeedPostVm()
        {
            Items = postDtos,
            TotalCount = totalCount,
            HasNextPage = hasNextPage
        };
    }
}