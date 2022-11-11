using Application.Users.Commands.CreateUser;

namespace Application.Common.Interfaces;
using Domain.Entities;

public interface ITokenServices
{
    string GenerateToken(NewUserDto userDto);
    ICollection<byte[]> CreateEncryptedPassword(string password);
    RefreshToken GenerateRefreshToken();
    void SetRefreshToken(RefreshToken token);
}