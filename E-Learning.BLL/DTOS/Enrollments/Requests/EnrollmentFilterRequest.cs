namespace E_Learning.BLL.DTOS.Enrollments.Request;

public record EnrollmentFilterRequest(
    int? LearnerId,
    int? CourseId,
    string? Status,
    DateOnly? FromDate,
    DateOnly? ToDate
);