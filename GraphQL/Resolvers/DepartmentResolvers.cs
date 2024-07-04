using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Resolvers;

public class DepartmentResolvers
{
    public async Task<List<Teacher>> GetTeachers(
        [Parent]Department department, 
        [Service]IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        return await dbcontext.Teachers
            .Where(x => x.DepartmentId == department.Id)
            .ToListAsync();
    }

    public async Task<List<Department>> GetDepartments([Service]IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        return await dbcontext.Departments.ToListAsync();
    }
}