
namespace SchoolManagementGraphQL.GraphQL.Types;

public class Query 
{
    public TeacherType? Teacher {get; set;} = new();
    public List<TeacherType> Teachers {get; set;} = new();
    public List<DepartmentType> Departments {get; set;} = new();

    // public async Task<List<Teacher>> GetTeachers([Service] AppDbContext context)
    //     => await context.Teachers.Include(x => x.Department).ToListAsync();

    // public async Task<Teacher?> GetTeacher(Guid id, [Service]AppDbContext context)
    //     => await context.Teachers.FindAsync(id);
}