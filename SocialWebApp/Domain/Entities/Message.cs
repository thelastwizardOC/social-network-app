using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SocialWebApp.Models;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string Photo { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
    
    public int SenderId { get; set; }
    [ForeignKey("SenderId")]
    public User Sender { get; set; }

    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
} 