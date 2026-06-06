using E_Learning.BLL.DTOS.Courses.Request;
using E_Learning.BLL.DTOS.Courses.Response;

namespace E_Learning.BLL.Services.Abstractions.Course
{
    public interface ICourseServices
    {

        Task<Result<PaginatedList<GetAllCoursesResponse>>> GetAllAsync(GetAllCourseRequest request);
        Task<Result<GetCourseByIdResponse>> GetByIdAsync(int Id);
        Task<Result> CreateAsync(CreateCourseRequest request);
        Task<Result> UpdateAsync(int Id, UpdateCourseRequest request);
        Task<Result> DeleteAsync(int Id);

    }
}
