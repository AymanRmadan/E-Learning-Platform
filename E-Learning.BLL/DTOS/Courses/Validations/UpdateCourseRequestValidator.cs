using E_Learning.BLL.DTOS.Courses.Request;

namespace E_Learning.BLL.Validations.Course
{
    public class UpdateCourseRequestValidator : AbstractValidator<UpdateCourseRequest>
    {
        public UpdateCourseRequestValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(c => c.DurationHours)
                .GreaterThan(0).WithMessage("DurationHours must be greater than 0");
        }
    }
}