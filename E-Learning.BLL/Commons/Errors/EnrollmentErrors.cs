namespace E_Learning.BLL.Commons.Errors;

public record LearnerErrors
{

    public static readonly Error LearnerNotFound =
        new("Learner.LearnerNotFound", "Learner is not found", StatusCodes.Status404NotFound);

    public static readonly Error FullNameRequired =
        new("Learner.LearnerBadRequest", "FullName is required", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidDuration =
        new("Learner.LearnerBadRequest", "Duration must be greater than 0", StatusCodes.Status400BadRequest);

    public static readonly Error NationalIdDuplicate =
          new("Learner.NationalIdDuplicate", "The National ID already exists", StatusCodes.Status400BadRequest);


}