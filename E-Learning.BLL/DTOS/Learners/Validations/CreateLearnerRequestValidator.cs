using E_Learning.BLL.DTOS.Learners.Request;

namespace E_Learning.BLL.DTOS.Learners.Validations
{
    public class CreateLearnerRequestValidator : AbstractValidator<CreateLearnerRequest>
    {
        public CreateLearnerRequestValidator()
        {
            RuleFor(l => l.FullName)
                .NotEmpty().WithMessage("FullName is required");

            RuleFor(l => l.NationalId)
                .NotEmpty().WithMessage("NationalId is required");

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid");
        }
    }
}
