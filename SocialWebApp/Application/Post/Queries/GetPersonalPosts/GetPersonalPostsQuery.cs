using System.Runtime.InteropServices;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Post.Queries.GetPersonalPosts;

public class GetPersonalPostsQuery: IRequest<PersonalPostVm>
{
    public int  UserId { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; }
}
public class GetPersonalPostsQueryHandler : IRequestHandler<GetPersonalPostsQuery, PersonalPostVm>
{
    private IApplicationDbContext _appDb;
    private readonly IMapper _mapper;

    public GetPersonalPostsQueryHandler(IApplicationDbContext appDb,IMapper mapper )
    {
        _appDb = appDb;
        _mapper = mapper;
    }

    public Task<PersonalPostVm> Handle(GetPersonalPostsQuery request, CancellationToken cancellationToken)
    {
        var post = _appDb.Post.Where(p=>p.UserId==request.UserId).Skip(request.Offset).Take(request.Limit);
        List<PersonalPostDto> postDtos = _mapper.Map<List<PersonalPostDto>>(post.ToList());
        int totalCount = postDtos.Count();

        bool hasNextPage = _appDb.Post.Count(p=>p.UserId==request.UserId) > request.Offset  + request.Limit ;  


        return Task.FromResult(new PersonalPostVm()
        {
            Items = postDtos,
            TotalCount = totalCount,
            HasNextPage = hasNextPage
        }); 
    }
}
