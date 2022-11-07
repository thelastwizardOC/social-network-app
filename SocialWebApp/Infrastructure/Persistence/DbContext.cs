using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using SocialWebApp.Models;


public class StudentContext : DbContext
{
    public StudentContext()
    {
    }
     

    public DbSet<User> User { get; set; }
    public DbSet<UserFriends> UserFriends { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Notification> Notification { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TestDB;User=sa;Password=12345OHdf%e;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }
        
        base.OnModelCreating(modelbuilder);
    }

    
}