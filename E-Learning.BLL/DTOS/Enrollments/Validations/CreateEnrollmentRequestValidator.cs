using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;

namespace E_Learning.BLL.DTOS.Enrollments.Validations
{
    public class CreateEnrollmentRequestValidator : AbstractValidator<CreateEnrollmentRequest>
    {
        public CreateEnrollmentRequestValidator()
        {
            RuleFor(e => e.LearnerId)
                .GreaterThan(0).WithMessage("Learner ID is required and must be valid");

            RuleFor(e => e.CourseId)
                .GreaterThan(0).WithMessage("Course ID is required and must be valid");
        }
    }
}
