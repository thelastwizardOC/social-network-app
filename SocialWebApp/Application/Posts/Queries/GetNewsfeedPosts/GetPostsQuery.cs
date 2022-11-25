using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts.Queries.GetNewsfeedPosts;

public class GetPostsQuery : IRequest<PaginatedPostDto>
{
    public int UserId { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; }
}

public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PaginatedPostDto>
{
    private IApplicationDbContext _appDb;
    private readonly IMapper _mapper;

    public GetPostsQueryHandler(IApplicationDbContext appDb, IMapper mapper)
    {
        _appDb = appDb;
        _mapper = mapper;
    }


    public async Task<PaginatedPostDto> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var foundUser = await _appDb.User.FirstOrDefaultAsync(u=>u.Id==request.UserId);
            if (foundUser == null) throw new NotFoundException();            
            var posts = await (
                from p in _appDb.Post
                join u in _appDb.User
                    on p.User.Id equals u.Id 
                join uf in _appDb.UserFriends 
                    on p.User.Id equals uf.FriendId into tmp_jointable
                from tmp in tmp_jointable.DefaultIfEmpty()
                where (p.User.Id == request.UserId || tmp.SourceUserId == request.UserId) 
                orderby p.CreatedAt descending
                select new PostDto()
                {
                    Id = p.Id,
                    Status = p.Status,
                    Photos = p.Photos,
                    NumberOfComments = p.NumberOfComments,
                    NumberOfLikes = p.NumberOfLikes,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    User = new User()
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        UserName = u.UserName,
                        Dob = u.Dob,
                        Email = u.Email,
                        Avatar = u.Avatar,
                        Cover = u.Cover,
                        Gender = u.Gender,
                        PhoneNo = u.PhoneNo,
                        CreatedAt = u.CreatedAt,
                        UpdatedAt = u.UpdatedAt
                    }
                }
            ).Skip(request.Offset).Take(request.Limit).ToListAsync();
            foreach (var post in posts)
            {
                var postLike =await _appDb.PostLike.Where(pl => pl.PostId == post.Id).ToListAsync();
                post.PostLikes=postLike;
            }
            
            List<PostDto> postDtos = _mapper.Map<List<PostDto>>(posts);
            int totalCount = postDtos.Count();
            bool hasNextPage = _appDb.Post.Count(p => p.User.Id == request.UserId) > request.Offset + request.Limit;


            return new PaginatedPostDto() { Items = postDtos, TotalCount = totalCount, HasNextPage = hasNextPage };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}