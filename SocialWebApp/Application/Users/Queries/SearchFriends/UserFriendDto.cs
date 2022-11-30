using Application.Users.Queries.GetUserInfo;

namespace Application.Users.Queries.SearchFriends;

public class UserFriendDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public int SourceUserId { get; set; }
    public UserDto SourceUser { get; set; }

    public int FriendId { get; set; }
    public UserDto Friend { get; set; }

}