using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Resolvers;

public class TeacherResolver
{
    public async Task<Department?> GetDepartment([Parent]Teacher teacher, [Service]IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        return await dbcontext.Departments.FindAsync(teacher.DepartmentId);
    }
    
    public async Task<List<Teacher>> GetTeachers([Service]IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        return await dbcontext.Teachers.ToListAsync();
    }
}