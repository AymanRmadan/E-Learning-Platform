using E_Learning.BLL;

namespace SurveyBasket.Contracts.Validations
{
    public class AddLoginRequestValidator : AbstractValidator<AddLoginRequest>
    {
        public AddLoginRequestValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty();


        }

    }
}
