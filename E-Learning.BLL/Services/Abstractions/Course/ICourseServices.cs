using E_Learning.BLL.DTOS.Courses.Request;
using E_Learning.BLL.DTOS.Courses.Response;

namespace E_Learning.BLL.Services.Abstractions.Course
{
    public interface ICourseServices
    {

        Task<Result<List<GetAllCoursesResponse>>> Get();
        Task<Result<GetCourseByIdResponse>> GetById(int Id);
        Task<Result> Create(CreateCourseRequest request);
        Task<Result> Update(int Id, UpdateCourseRequest request);
        Task<Result> Delete(int Id);

    }
}
