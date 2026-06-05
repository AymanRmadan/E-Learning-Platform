using E_Learning.BLL.DTOS.Enrollments.Request;

namespace E_Learning.BLL.DTOS.Enrollments.Validations
{
    public class EnrollmentDecisionRequestValidator : AbstractValidator<EnrollmentDecisionRequest>
    {
        public EnrollmentDecisionRequestValidator()
        {
            RuleFor(d => d.Decision)
                .NotEmpty().WithMessage("Decision is required")
                .Must(d => d == "Approved" || d == "Rejected")
                .WithMessage("Decisions can only be 'Approved' or 'Rejected'");


            RuleFor(d => d.Reason)
                .NotEmpty()
                .When(d => d.Decision == "Rejected")
                .WithMessage("Rejected enrollments must have a reason");
        }
    }
}