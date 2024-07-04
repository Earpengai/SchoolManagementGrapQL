
using SchoolManagementGraphQL.Data;

namespace SchoolManagementGraphQL.GraphQL.Types;

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field(x => x.Teacher)
            .Name("teacher")
            .Description("This is the teacher in the school.")
            .Type<TeacherType>()
            .Argument("id", a => 
                a.Type<NonNullType<UuidType>>())
            .Resolve(async context => {
                var id = context.ArgumentValue<Guid>("id");
                return await context.Service<AppDbContext>().Teachers.FindAsync(id);
            });
    }
}