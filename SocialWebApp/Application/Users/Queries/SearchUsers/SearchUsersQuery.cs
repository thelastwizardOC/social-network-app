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
            var users = from u in _context.User select u; 
            var userList = await users.Where(u => u.UserName.Contains(request.SearchString)
                                     || (u.FirstName + ' ' + u.LastName).Contains(request.SearchString)
                                     || (u.LastName + ' ' + u.FirstName).Contains(request.SearchString)).OrderBy(u => u.FirstName).AsNoTracking().ToListAsync();

            int totalCount = userList.Count();
            bool hasNextPage = totalCount > request.Limit + request.Offset;
            var searchUsersResult = _mapper.Map<List<User>, List<SearchUserDto>>(userList);

            var friends = await (from f in _context.UserFriends select new {f.SourceUserId, f.FriendId}).AsNoTracking().ToListAsync();
            
            searchUsersResult.ForEach(i =>
            {
                if (i.Id == request.UserId)
                {
                    i.Relationship = RelationshipType.Self;
                }
                else if (friends.FirstOrDefault(x => x.FriendId == i.Id || x.SourceUserId == i.Id) != default)
                {
                    i.Relationship = RelationshipType.Friend;
                }
                else
                {
                    i.Relationship = RelationshipType.NotFriend;
                }
            });
            var paginatedList = searchUsersResult.OrderBy(user => user.Relationship).Skip(request.Offset).Take(request.Limit);
            
            return new SearchUsersListDto()
            {
                Users = paginatedList.ToList(),
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