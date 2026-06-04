

using E_Learning.BLL.DTOS.Courses.Request;
using E_Learning.BLL.DTOS.Courses.Response;
using E_Learning.Domain.Repositories.Abstractions;

namespace E_Learning.BLL.Services.Implementations.Course;

public class CourseServices : ICourseServices
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Create(CreateCourseRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return Result.Failure(CourseErrors.TitleRequired);

        if (request.DurationHours <= 0)
            return Result.Failure(CourseErrors.InvalidDuration);

        var course = request.Adapt<Domain.Entities.Course>();
        course.IsActive = true;

        await _unitOfWork.Courses.InsertAsync(course);
        await _unitOfWork.SaveChangeAsync();

        return Result.Success();
    }


    public async Task<Result<List<GetAllCoursesResponse>>> Get()
    {
        var courses = await _unitOfWork.Courses.GetAllAsync();

        var response = courses.Adapt<List<GetAllCoursesResponse>>();

        return Result.Success(response!);
    }

    public async Task<Result<GetCourseByIdResponse>> GetById(int Id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(Id);
        if (course == null)
            return Result.Failure<GetCourseByIdResponse>(CourseErrors.CourseNotFound);

        var response = course.Adapt<GetCourseByIdResponse>();
        return Result.Success(response!);
    }

    public async Task<Result> Update(int Id, UpdateCourseRequest request)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(Id);
        if (course == null)
            return Result.Failure<GetCourseByIdResponse>(CourseErrors.CourseNotFound);

        request.Adapt(course);

        _unitOfWork.Courses.Update(course);
        await _unitOfWork.SaveChangeAsync();

        return Result.Success();
    }
    public async Task<Result> Delete(int Id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(Id);
        if (course == null)
            return Result.Failure<GetCourseByIdResponse>(CourseErrors.CourseNotFound);

        _unitOfWork.Courses.Delete(course);
        await _unitOfWork.SaveChangeAsync();
        return Result.Success();
    }
}

