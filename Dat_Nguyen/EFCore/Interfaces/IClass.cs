using EFCore.Models;

namespace EFCore.Interfaces;

public interface IClass
{
    void CreateClass(ICollection<Student> students, Teacher teacher, Subject subject);
}