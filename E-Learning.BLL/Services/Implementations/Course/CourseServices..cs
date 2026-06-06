

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
    public async Task<Result> CreateAsync(CreateCourseRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return Result.Failure(CourseErrors.TitleRequired);

        if (request.DurationHours <= 0)
            return Result.Failure(CourseErrors.InvalidDuration);

        var course = request.Adapt<Domain.Entities.Course>();


        await _unitOfWork.Courses.InsertAsync(course);
        await _unitOfWork.SaveChangeAsync();

        return Result.Success();
    }


    public async Task<Result<PaginatedList<GetAllCoursesResponse>>> GetAllAsync(GetAllCourseRequest request)
    {
        var courses = _unitOfWork.Courses.GetQueryable()
                                   .AsNoTracking()
                                   .ProjectToType<GetAllCoursesResponse>();

        var response = await PaginatedList<GetAllCoursesResponse>.CreateAsync(
                                                courses,
                                                request.PageNumber,
                                                request.PageSize
                                            );

        return Result.Success(response);
    }

    public async Task<Result<GetCourseByIdResponse>> GetByIdAsync(int Id)
    {
        var course = await _unitOfWork.Courses.GetQueryable()
                                       .Where(c => c.Id == Id)
                                       .AsNoTracking()
                                       .ProjectToType<GetCourseByIdResponse>()
                                       .FirstOrDefaultAsync();
        if (course == null)
            return Result.Failure<GetCourseByIdResponse>(CourseErrors.CourseNotFound);


        return Result.Success(course);
    }

    public async Task<Result> UpdateAsync(int Id, UpdateCourseRequest request)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(Id);
        if (course == null)
            return Result.Failure<UpdateCourseRequest>(CourseErrors.CourseNotFound);

        request.Adapt(course);

        _unitOfWork.Courses.Update(course);
        await _unitOfWork.SaveChangeAsync();

        return Result.Success();
    }
    public async Task<Result> DeleteAsync(int Id)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(Id);
        if (course == null)
            return Result.Failure<UpdateCourseRequest>(CourseErrors.CourseNotFound);

        _unitOfWork.Courses.Delete(course);
        await _unitOfWork.SaveChangeAsync();
        return Result.Success();
    }
}

