using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Queries;

public class Query 
{
    public async Task<List<Teacher>> GetTeachers([Service] AppDbContext context)
        => await context.Teachers.ToListAsync();
}