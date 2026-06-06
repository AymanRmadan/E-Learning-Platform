namespace E_Learning.BLL.DTOS.Courses.Request;
public record GetAllCourseRequest(
    int PageNumber = 1,
    int PageSize = 3,
    string? SearchTerm = null
    );