using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.UploadAvatar;

public record UploadCoverCommand(
    int Id,
    string base64
) : IRequest<string>;

public class UploadCoverCommandHandler : IRequestHandler<UploadCoverCommand, string>
{
    private readonly IApplicationDbContext _context;
    
    public UploadCoverCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UploadCoverCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Id == request.Id);
        if (user == null) return null;
        user.Cover = request.base64;
        await _context.SaveChangesAsync();
        return user.Cover;
    }
}