namespace E_Learning.BLL.Commons.Errors;

public record CourseErrors
{

    public static readonly Error CourseNotFound =
        new("Course.CourseNotFound", "Course is not found", StatusCodes.Status404NotFound);

    public static readonly Error TitleRequired =
        new("Course.CourseBadRequest", "Title is required", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidDuration =
        new("Course.CourseBadRequest", "Duration must be greater than 0", StatusCodes.Status400BadRequest);


}