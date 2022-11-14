using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.UploadAvatar;

public record UploadAvatarCommand(
    int Id,
    IFormFile file
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
        string base64;
        using (var ms = new MemoryStream())
        {
            request.file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            base64 = Convert.ToBase64String(fileBytes);
        }
        user.Avatar = base64;
        await _context.SaveChangesAsync();
        return user.Avatar;
    }
}



