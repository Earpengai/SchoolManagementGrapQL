using SchoolManagementGraphQL.Data;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Types;

public class TeacherType : ObjectType<Teacher>
{
    protected override void Configure(IObjectTypeDescriptor<Teacher> descriptor)
    {
        descriptor.Field(x => x.Department)
            .Name("department")
            .Description("This is the department which the teacher belongs.")
            .Resolve(async context => {
                return await context.Service<AppDbContext>().Departments
                    .FindAsync(context.Parent<Teacher>().DepartmentId);
            });
    }
}