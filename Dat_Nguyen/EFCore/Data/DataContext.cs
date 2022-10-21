using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options){}
    
    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Subject> Subject { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost; Database=sondeptraiDB; User Id=sa; Password=Adminxyz22#;Integrated Security=false;");
    }
    
}