namespace E_Learning.BLL.DTOS.Courses.Response
{
    public record GetCourseByIdResponse
        (
        int Id,
        string Title,
        int DurationHours,
        bool RequiresApproval,
        bool IsActive
        );
}
