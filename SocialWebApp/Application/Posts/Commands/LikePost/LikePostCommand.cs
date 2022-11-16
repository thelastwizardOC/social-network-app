using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Posts.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts.Commands.LikePost;

public class LikePostCommand:IRequest<PostDto>
{
    public int PostId { get; set; }
    public int UserId { get; set; }
}


public class LikePostCommandHandler: IRequestHandler<LikePostCommand, PostDto>{
    private IApplicationDbContext _appDb;
    private readonly IMapper _mapper;

    public LikePostCommandHandler(IApplicationDbContext appDb,IMapper mapper )
    {
        _appDb = appDb;
        _mapper = mapper;
    }
    public async Task<PostDto> Handle(LikePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var foundUser = await _appDb.User.FirstOrDefaultAsync(u=>u.Id==request.UserId);
            if (foundUser == null) throw new NotFoundException();
            var foundPost = await _appDb.Post.Where(p=>p.Id == request.PostId).Include(p=>p.User).Include(p=>p.PostLikes).FirstOrDefaultAsync();
            var checkUserLiked =
                await _appDb.PostLike.FirstOrDefaultAsync(p =>
                    p.PostId == request.PostId && p.UserId == request.UserId);
            if (checkUserLiked == null)
            {
                foundPost.NumberOfLikes++;
                _appDb.PostLike.Add(new PostLike()
                {
                    UserId = request.UserId,
                    PostId = request.PostId
                }); 
            }
            else
            {
                foundPost.NumberOfLikes--;
                _appDb.PostLike.Remove(checkUserLiked);
            }
         
           await _appDb.SaveChangesAsync();
           var postDto = _mapper.Map<PostDto>(foundPost);
           return postDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}