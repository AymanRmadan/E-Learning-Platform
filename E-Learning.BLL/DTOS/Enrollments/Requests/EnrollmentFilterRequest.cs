namespace E_Learning.BLL.DTOS.Enrollments.Request;

public record EnrollmentFilterRequest(
    int? LearnerId,
    int? CourseId,
    string? Status,
    DateTime? FromDate,
    DateTime? ToDate
);