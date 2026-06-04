using E_Learning.BLL.DTOS.Passwords.Requests;

namespace E_Learning.BLL.DTOS.Passwords.Validations
{
    public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
    {
        public ForgetPasswordRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();


        }
    }
}
