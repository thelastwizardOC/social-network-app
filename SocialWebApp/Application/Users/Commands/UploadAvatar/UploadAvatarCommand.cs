using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.UploadAvatar;

public record UploadAvatarCommand(
    int UserId,
    string Base64
) : IRequest<string>;

public class UploadAvatarCommandHandler : IRequestHandler<UploadAvatarCommand, string>
{
    private readonly IApplicationDbContext _context;
    
    public UploadAvatarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UploadAvatarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == request.UserId);
            if (user == null) throw new NotFoundException(nameof(User), request.UserId);
            
            user.Avatar = request.Base64;
            Photo photo = new Photo()
            {
                PhotoString = request.Base64,
                CreatedAt = DateTime.Now,
                UserId = user.Id
            };
            _context.Photo.Add(photo);
            await _context.SaveChangesAsync();
            return user.Avatar;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}



