using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.GraphQL.DataLoaders;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Resolvers;

public class TeacherResolver
{
    public async Task<Department?> GetDepartment(
        [Parent]Teacher teacher, 
        DepartmentByTeacherIdBatchDataLoader departmentByTeacherIdBatchDataLoader,
        CancellationToken cancellationToken)
    {
        var department = await departmentByTeacherIdBatchDataLoader.LoadAsync(teacher.DepartmentId, cancellationToken);
        return department;
    }
    
    public async Task<List<Teacher>> GetTeachers([Service]IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        return await dbcontext.Teachers.ToListAsync();
    }
}