using EFCore.Data;
using EFCore.Interfaces;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services;

public class ClassServices:IClass
{
    private readonly DataContext _context;

    public ClassServices(DataContext context)
    {
        _context = context;
        
        var teacher = new Teacher();
        teacher.Name = "John Doe";
        teacher.Subjects = new List<Subject>() { };
        var subject = new Subject();
        subject.Name = "Basic Programming";
        subject.TeacherId = 0;
        var student = new Student();
        student.Name = "Harry";
        student.IsMale = true;
        student.Subjects = new List<Subject>() { subject };
        
        // _context.Students.Add(student);
        // _context.Teachers.Add(teacher);
        // _context.Subjects.Add(subject);
    }

    public async Task<List<Student>> GetAllInfo()
    {
        var students = await _context.Student.ToListAsync();
        return students;
    }

    public void CreateClass(ICollection<Student> students, Teacher teacher, Subject subject)
    {
        throw new NotImplementedException();
    }
}