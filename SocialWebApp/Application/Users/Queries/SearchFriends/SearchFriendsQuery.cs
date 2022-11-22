using System.Collections;
using Application.Common.Interfaces;
using Application.Posts.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.SearchFriends;

public record SearchFriendsQuery(string SearchString, int Offset, int Limit) : IRequest<SearchUsersListDto>;

public class SearchFriendsQueryHandler : IRequestHandler<SearchFriendsQuery, SearchUsersListDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchFriendsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SearchUsersListDto> Handle(SearchFriendsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = from u in _context.User select u;
            users = users.Where(u => u.UserName.Contains(request.SearchString)
                                     || u.FirstName.Contains(request.SearchString)
                                     || u.LastName.Contains(request.SearchString)).OrderBy(u => u.FirstName);
            int totalCount = await users.CountAsync();
            var paginatedList = await users.Skip(request.Offset).Take(request.Limit).ToListAsync();
            bool hasNextPage = totalCount > request.Limit + request.Offset;
            return new SearchUsersListDto()
            {
                Users = _mapper.Map<List<User>, List<SearchUserDto>>(paginatedList),
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