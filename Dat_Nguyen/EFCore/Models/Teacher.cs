using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EFCore.Models;

[Table("Teacher")]
public class Teacher
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    // public int SubjectId { get; set; }
    // public Subject Subject { get; set; }
    public ICollection<Subject> Subjects { get; set; }
}