using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<SocialWebApp.Models.User> User { get; set; }
    public DbSet<UserFriends> UserFriends { get; set; }
    public DbSet<SocialWebApp.Models.Post> Post { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Photo> Photo { get; set; }
    Task<int> SaveChangesAsync();
}