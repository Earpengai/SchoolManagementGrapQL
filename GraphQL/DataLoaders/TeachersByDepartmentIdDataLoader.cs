using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.DataLoaders;

public class TeachersByDepartmentIdDataLoader(
    IDbContextFactory<AppDbContext> dbContextFactory,
    IBatchScheduler batchScheduler,
    DataLoaderOptions? options = null)
    : GroupedDataLoader<Guid, Teacher>(batchScheduler, options)
{
    protected override async Task<ILookup<Guid, Teacher>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        var teacher = await context.Teachers
            .Where(x => keys.Contains(x.DepartmentId))
            .ToListAsync(cancellationToken);
        return teacher.ToLookup(x => x.DepartmentId);
    }
}