using E_Learning.BLL.DTOS.Courses.Request;

namespace E_Learning.BLL.DTOS.Courses.Validations
{
    public class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(c => c.DurationHours)
                .GreaterThan(0).WithMessage("DurationHours must be greater than 0.");
        }
    }
}
