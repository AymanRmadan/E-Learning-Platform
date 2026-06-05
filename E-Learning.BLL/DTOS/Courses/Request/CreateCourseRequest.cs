namespace E_Learning.BLL.DTOS.Courses.Request
{
    public record CreateCourseRequest
    (
        string Title,
        string Description,
        int DurationHours,
        bool RequiresApproval,
         bool IsActive
        );
}
