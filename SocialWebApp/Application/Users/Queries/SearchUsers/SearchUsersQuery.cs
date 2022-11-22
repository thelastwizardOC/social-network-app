using System.Collections;
using Application.Common.Interfaces;
using Application.Posts.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.SearchUsers;

public record SearchUsersQuery
    (int UserId, string SearchString, int Offset = 0, int Limit = 100) : IRequest<SearchUsersListDto>;

public class SearchUsersQueryHandler : IRequestHandler<SearchUsersQuery, SearchUsersListDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SearchUsersListDto> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users =
                from u in _context.User
                from f in _context.UserFriends.Where(f => f.SourceUserId == u.Id || f.FriendId == u.Id)
                    .DefaultIfEmpty()
                select u;
            // users = users.Where(u => u.UserName.Contains(request.SearchString)
            //                          || u.FirstName.Contains(request.SearchString)
            //                          || u.LastName.Contains(request.SearchString)).OrderBy(u => u.FirstName);
            int totalCount = await users.CountAsync();
            var paginatedList = await users.Skip(request.Offset).Take(request.Limit).ToListAsync();
            bool hasNextPage = totalCount > request.Limit + request.Offset;
            var searchUsersResult = _mapper.Map<List<User>, List<SearchUserDto>>(paginatedList);
            
            return new SearchUsersListDto()
            {
                Users = searchUsersResult,
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