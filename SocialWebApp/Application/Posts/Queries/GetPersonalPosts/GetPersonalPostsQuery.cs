using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts.Queries.GetPersonalPosts;

public class GetPersonalPostsQuery : IRequest<PersonalPostVm>
{
  public int UserId { get; set; }
  public int Offset { get; set; }
  public int Limit { get; set; }
}
public class GetPersonalPostsQueryHandler : IRequestHandler<GetPersonalPostsQuery, PersonalPostVm>
{
  private IApplicationDbContext _appDb;
  private readonly IMapper _mapper;

  public GetPersonalPostsQueryHandler(IApplicationDbContext appDb, IMapper mapper)
  {
    _appDb = appDb;
    _mapper = mapper;
  }

  public async Task<PersonalPostVm> Handle(GetPersonalPostsQuery request, CancellationToken cancellationToken)
  {
    try
    {
      var post = await _appDb.Post.Where(p => p.User.Id == request.UserId).OrderByDescending(p => p.CreatedAt).Include(p => p.User).Skip(request.Offset).Take(request.Limit).ToListAsync();
      List<PersonalPostDto> postDtos = _mapper.Map<List<PersonalPostDto>>(post);
      int totalCount = postDtos.Count();
      bool hasNextPage = await _appDb.Post.CountAsync(p => p.User.Id == request.UserId) > request.Offset + request.Limit;
      return new PersonalPostVm()
      {
        Items = postDtos,
        TotalCount = totalCount,
        HasNextPage = hasNextPage
      };
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }

  }
}
