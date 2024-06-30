using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<TeacherCourse> TeacherCourses => Set<TeacherCourse>();
    public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();
    public DbSet<LabRoom> LabRooms => Set<LabRoom>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();
    public DbSet<Equipment> Equipment => Set<Equipment>();
    public DbSet<Furniture> Furnitures => Set<Furniture>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureModels();
        modelBuilder.SeedData();
        //base.OnModelCreating(modelBuilder);
    }
}
