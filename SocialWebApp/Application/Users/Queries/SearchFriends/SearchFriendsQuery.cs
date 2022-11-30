using Application.Common.Interfaces;
using Application.Users.Queries.GetUserInfo;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.SearchFriends;

public class SearchFriendsQuery : IRequest<List<UserDto>>
{
    public int SourceUserId { get; set; }
    public string Keyword { get; set; } = "";
}

public class SearchFriendsQueryHandler : IRequestHandler<SearchFriendsQuery, List<UserDto>>
{
    private IApplicationDbContext _appDb;
    private readonly IMapper _mapper;

    public SearchFriendsQueryHandler(IApplicationDbContext appDb, IMapper mapper)
    {
        _appDb = appDb;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(SearchFriendsQuery request, CancellationToken cancellationToken)
    {
        var userFriends = await _appDb.UserFriends.Where(uf => uf.SourceUserId == request.SourceUserId).Include(uf=>uf.Friend).ToListAsync();
        var searchedUserFriends =
            userFriends.Where(f => f.Friend.FirstName.ToLower().Contains(request.Keyword.ToLower()) 
                                   || f.Friend.LastName.ToLower().Contains(request.Keyword.ToLower())
                                   || f.Friend.UserName.ToLower().Contains(request.Keyword.ToLower())).ToList();

        var userDto = _mapper.Map<List<UserDto>>(searchedUserFriends.Select(u=>u.Friend));
        return userDto;
    }
}