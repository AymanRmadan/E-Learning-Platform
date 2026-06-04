namespace E_Learning.BLL.DTOS.Courses.Request
{
    public record UpdateCourseRequest
    (
        string Title,
        string Description,
        int DurationHours,
        bool RequiresApproval,
        bool IsActive
        );
}
