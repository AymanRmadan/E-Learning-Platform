namespace E_Learning.BLL.DTOS.Enrollments.Response;

public record EnrollmentResponse(
    int Id,
    DateTime EnrollmentDate,
    string Status,
    DateTime? DecisionDate,
    string? RejectionReason,
    LearnerInfo Learner,
    CourseInfo Course
);
