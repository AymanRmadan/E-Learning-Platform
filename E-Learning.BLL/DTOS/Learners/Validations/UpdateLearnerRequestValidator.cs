using E_Learning.BLL.DTOS.Learners.Request;

namespace E_Learning.BLL.Validations.Learners
{
    public class UpdateLearnerRequestValidator : AbstractValidator<UpdateLearnerRequest>
    {
        public UpdateLearnerRequestValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("FullName is required");

            RuleFor(c => c.NationalId)
                .NotEmpty().WithMessage("NationalId is required");
        }
    }
}