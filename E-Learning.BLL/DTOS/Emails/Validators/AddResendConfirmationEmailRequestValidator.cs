namespace E_Learning.BLL
{
    public class AddResendConfirmationEmailRequestValidator : AbstractValidator<AddResendConfirmationEmailRequest>
    {
        public AddResendConfirmationEmailRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
