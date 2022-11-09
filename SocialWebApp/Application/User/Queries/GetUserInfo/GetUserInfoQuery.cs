using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.User.Queries.GetUserInfo;

public class GetUserInfoQuery : IRequest<UserDto>
{
    public int UserId { get; set; }
}


public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDto>
{
    private IApplicationDbContext _appDb;
    private readonly IMapper _mapper;

    public GetUserInfoQueryHandler(IApplicationDbContext appDb ,IMapper mapper )
    {
        _appDb = appDb;
        _mapper = mapper;
    }
    public Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = _appDb.User.FirstOrDefault(u=>u.Id==request.UserId);
        var userDto = _mapper.Map<UserDto>(user);
        return Task.FromResult(userDto);
    }
}