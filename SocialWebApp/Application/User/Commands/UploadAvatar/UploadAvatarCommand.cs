using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.UploadAvatar;

public record UploadAvatarCommand(
    int Id,
    string base64
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
        var user = await _context.User.FirstOrDefaultAsync(u => u.Id == request.Id);
        if (user == null) return null;
        user.Avatar = request.base64;
        await _context.SaveChangesAsync();
        return user.Avatar;
    }
}



