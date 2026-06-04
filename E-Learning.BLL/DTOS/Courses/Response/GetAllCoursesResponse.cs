namespace E_Learning.BLL.DTOS.Courses.Response
{
    public record GetAllCoursesResponse
        (
        int Id,
        string Title,
        string Description,
        int DurationHours,
        bool RequiresApproval,
        bool IsActive
        );
}
