using Microsoft.EntityFrameworkCore;
using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.DataLoaders;

public class DepartmentByTeacherIdBatchDataLoader(
    IDbContextFactory<AppDbContext> dbContextFactory,
    IBatchScheduler batchScheduler,
    DataLoaderOptions? options = null)
    : BatchDataLoader<Guid, Department> (batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<Guid, Department>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        await using var dbcontext = await dbContextFactory.CreateDbContextAsync();
        var department = await dbcontext.Departments
            .Where(x => keys.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
        return department;
    }
}