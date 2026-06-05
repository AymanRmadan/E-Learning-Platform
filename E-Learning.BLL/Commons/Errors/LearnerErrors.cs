namespace E_Learning.BLL.Commons.Errors;

public record EnrollmentErrors
{

    public static readonly Error AlreadyEnrolled =
        new("Enrollment.AlreadyEnrolled", "The learner is already enrolled in this course", StatusCodes.Status400BadRequest);
    public static readonly Error InactiveCourse =
       new("Enrollment.InactiveCourse", "Cannot enroll in an inactive course", StatusCodes.Status400BadRequest);
    public static readonly Error CourseNotFound =
       new("Enrollment.CourseNotFound", "The specified course does not exist", StatusCodes.Status404NotFound);
    public static readonly Error LearnerNotFound =
       new("Enrollment.LearnerNotFound", "The specified learner does not exist", StatusCodes.Status404NotFound);




}