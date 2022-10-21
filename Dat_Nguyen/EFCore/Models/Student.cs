using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EFCore.Models;
using System.ComponentModel.DataAnnotations;

[Table("Student")]
public class Student
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public bool IsMale { get; set; } = true;
    public virtual ICollection<Subject> Subjects { get; set; }

}