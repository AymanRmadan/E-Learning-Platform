namespace E_Learning.BLL.DTOS.Enrollments.Response;

public record EnrollmentResponse(
    int Id,
    DateOnly EnrollmentDate,
    string Status,
    DateOnly? DecisionDate,
    string? RejectionReason,
    LearnerInfo Learner,
    CourseInfo Course
);
