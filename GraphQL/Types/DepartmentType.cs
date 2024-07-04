using SchoolManagementGraphQL.GraphQL.Resolvers;
using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Types;

public class DepartmentType : ObjectType<Department>
{
    protected override void Configure(IObjectTypeDescriptor<Department> descriptor)
    {
        descriptor.Field(x => x.Teachers)
            .Description("This is the list teacher in department.")
            .Type<ListType<TeacherType>>()
            .ResolveWith<DepartmentResolvers>(x => x.GetTeachers(default, default));
    }
}