using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Response;

namespace E_Learning.BLL.Services.Abstractions.Enrollment
{
    public interface IEnrollmentServices
    {
        Task<Result> EnrollAsync(CreateEnrollmentRequest request, int userId);

        Task<Result> TakeDecisionAsync(int enrollmentId, EnrollmentDecisionRequest request);

        Task<Result<IReadOnlyList<EnrollmentResponse>>> GetAllAsync(int? LearnerId, int? CourseId, string? Status, DateTime? FromDate, DateTime? ToDate);
    }
}
