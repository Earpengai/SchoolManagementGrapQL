using SchoolManagementGraphQL.Models;

namespace SchoolManagementGraphQL.GraphQL.Mutations;

public class AddTeacherPayload(Teacher teacher)
{
    public Teacher Teacher { get; } = teacher;
}