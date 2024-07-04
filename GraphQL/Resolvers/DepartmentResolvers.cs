using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.GraphQL.DataLoaders;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Resolvers;

public class DepartmentResolvers
{
    public async Task<List<Teacher>> GetTeachers(
        [Parent]Department department, 
        TeachersByDepartmentIdDataLoader teachersByDepartmentIdDataLoader,
        CancellationToken cancellationToken)
    {
        var teachers = await teachersByDepartmentIdDataLoader
            .LoadAsync(department.Id, cancellationToken);
        return teachers.ToList();    
    }

    public async Task<List<Department>> GetDepartments([Service]IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        return await dbcontext.Departments.ToListAsync();
    }
}