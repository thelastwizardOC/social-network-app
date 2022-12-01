using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.AddFriend;

public record AddFriendCommand(
    int SourceUserId,
    int ReceiveUserId
    ) : IRequest<bool>;

public class AddFriendCommandHandler : IRequestHandler<AddFriendCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IHubContext<NotificationHub> _hub;
    private readonly IMapper _mapper;

    public AddFriendCommandHandler(IApplicationDbContext context, IHubContext<NotificationHub> hub, IMapper mapper)
    {
        _context = context;
        _hub = hub;
        _mapper = mapper;
    }

    public async Task<bool> Handle(AddFriendCommand request, CancellationToken cancellationToken)
    {
        var sourceUser = await _context.User.FirstOrDefaultAsync(u => u.Id == request.SourceUserId); 
        _context.UserFriends.Add(new UserFriends()
        {
            CreatedAt = DateTime.Now,
            SourceUserId = request.SourceUserId,
            FriendId = request.ReceiveUserId
        });
        _context.Notification.Add(new Notification()
        {
            Type = 0,
            Content = "Add friend",
            IsRead = false,
            CreatedAt = DateTime.Now,
            UserId = request.ReceiveUserId,
            TriggerUserId = request.SourceUserId
        });
        await _context.SaveChangesAsync();
        var returnSourceUser = _mapper.Map<User, NotificationUserDto>(sourceUser);
        await _hub.Clients.Group($"user_{request.ReceiveUserId}").SendAsync("addFriendNotification", new NotificationDto()
        {
            TriggerUser = returnSourceUser,
            Type = 0,
            CreatedAt = DateTime.Now,
        });
        return true;
    }
}