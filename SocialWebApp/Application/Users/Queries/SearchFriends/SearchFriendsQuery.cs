using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.SearchFriends;

public record SearchFriendsQuery
    (int UserId, string SearchString = "", int Offset = 0, int Limit = 100) : IRequest<SearchFriendsListDto>;

public class SearchFriendsQueryHandler : IRequestHandler<SearchFriendsQuery, SearchFriendsListDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchFriendsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SearchFriendsListDto> Handle(SearchFriendsQuery request, CancellationToken token)
    {
        var lowerCaseKeyword = request.SearchString.ToLower();
        var userFriends = await _context.UserFriends.Where(uf => uf.SourceUserId == request.UserId)
            .Include(uf => uf.Friend).ToListAsync();
        var searchedUserFriends =
            userFriends.Where(f => (f.Friend.FirstName + ' ' + f.Friend.LastName).Contains(lowerCaseKeyword)
                                   || (f.Friend.LastName + ' ' + f.Friend.FirstName).Contains(lowerCaseKeyword)
                                   || f.Friend.UserName.ToLower().Contains(lowerCaseKeyword)).ToList();
        // var friendList =
        //     await (from u in _context.User
        //         join uf in _context.UserFriends
        //             on u.Id equals uf.FriendId
        //         where uf.SourceUserId == request.UserId &&
        //               (u.FirstName + ' ' + u.LastName).Contains(request.SearchString)
        //               || (u.LastName + ' ' + u.FirstName).Contains(request.SearchString) ||
        //               u.UserName.Contains(request.SearchString)
        //         orderby u.FirstName
        //         select u).ToListAsync();

         int totalCount = searchedUserFriends.Count();
        bool hasNextPage = totalCount > request.Limit + request.Offset;

        var paginatedList = searchedUserFriends.Select(u => u.Friend).Skip(request.Offset).Take(request.Limit).ToList();

        return new SearchFriendsListDto()
        {
            Friends = _mapper.Map<List<User>, List<SearchFriendDto>>(paginatedList),
            TotalCount = totalCount,
            HasNextPage = hasNextPage
        };
    }
}