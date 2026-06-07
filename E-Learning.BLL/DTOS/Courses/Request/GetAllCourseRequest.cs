namespace E_Learning.BLL.DTOS.Courses.Request;
public record GetAllCourseRequest(
    int PageNumber = 1,
    int PageSize = 10,
    string? SearchTerm = null
    );