using E_Learning.BLL.Services.Abstractions.Learner;

namespace E_Learning.BLL.DTOS.Register.Validators
{
    public class AddRegisterRequestValidator : AbstractValidator<AddRegisterRequest>
    {
        private readonly ILearnerServices _learnerServices;

        public AddRegisterRequestValidator(ILearnerServices learnerServices)
        {
            _learnerServices = learnerServices;


            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();


            RuleFor(r => r.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase");

            RuleFor(l => l.Name)
                .NotEmpty().WithMessage("FullName is required");

            RuleFor(l => l.NationalId)
             .NotEmpty().WithMessage("NationalId is required");

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid");

        }

    }
}
