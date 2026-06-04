namespace E_Learning.BLL
{
    public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailRequestValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty();


            RuleFor(r => r.Code)
                .NotEmpty();

        }

    }
}