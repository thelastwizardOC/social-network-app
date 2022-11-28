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
        var userFriends = _context.User.Join(_context.UserFriends,
            user => user.Id,
            userFriends => userFriends.SourceUserId,
            (user, userFriends) => _mapper.Map<User, SearchFriendDto>(user)).AsNoTracking();
        var friends = userFriends
            .Where(u => u.Id == request.UserId 
                        && u.FirstName == request.SearchString
                        && u.LastName == request.SearchString
                        && u.Username == request.SearchString).OrderBy(u => u.FirstName).AsNoTracking();
        int totalCount = friends.Count();
        bool hasNextPage = totalCount > request.Limit + request.Offset;

        var paginatedList = await friends.Skip(request.Offset).Take(request.Limit).ToListAsync();
        
        return new SearchFriendsListDto()
        {
            
        }
    }
}