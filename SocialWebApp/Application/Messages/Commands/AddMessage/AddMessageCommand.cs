using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Messages.Queries.GetUserMessage;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Messages.Commands.AddMessage;

public class AddMessageCommand: IRequest<UserMessageDto>
{
    public string Content { get; set; }
    public int SenderId  { get; set; }
    public int ReceiverId { get; set; }

    public int Type { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand, UserMessageDto>
{
  private readonly IApplicationDbContext _appDb;
  private readonly IMapper _mapper;

  public AddMessageCommandHandler(IApplicationDbContext appDb, IMapper mapper)
  {
    _appDb = appDb;
    _mapper = mapper;
  }

  public async Task<UserMessageDto> Handle(AddMessageCommand request, CancellationToken cancellationToken)
  {
      
          bool isFriend = await _appDb.UserFriends.AnyAsync(u =>
              (u.SourceUserId == request.SenderId && u.FriendId == request.ReceiverId) ||
              (u.SourceUserId == request.ReceiverId && u.FriendId == request.SenderId));

          if (!isFriend) throw new NotFoundException();
          var addMessage = new Message()
          {
              Content = request.Content,
              IsRead = false,
              ReceiverId = request.ReceiverId,
              SenderId = request.SenderId,
              Type = request.Type,
              CreatedAt = DateTime.Now,
          };
          await _appDb.Message.AddAsync(addMessage);
          await _appDb.SaveChangesAsync();

          addMessage.Receiver = await _appDb.User.FindAsync(addMessage.ReceiverId);
          addMessage.Sender = await _appDb.User.FindAsync(addMessage.SenderId);
          var messageDto = _mapper.Map<UserMessageDto>(addMessage);

          return messageDto;
      }
   
}
