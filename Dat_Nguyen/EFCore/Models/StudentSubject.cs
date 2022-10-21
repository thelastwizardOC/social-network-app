namespace EFCore.Models;

public class StudentSubject
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}