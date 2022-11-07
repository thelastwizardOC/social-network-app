using MediatR;

namespace Application.User.Queries.GetUserInfo;

public class GetUserInfoQuery : IRequest<UserDto>
{
}


public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDto>
{
    public Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new UserDto() { FirstName = "hoang", LastName = "truong" });
    }
}