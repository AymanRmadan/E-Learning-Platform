using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Request;

namespace E_Learning.BLL.Services.Abstractions.Enrollment
{
    public interface IEnrollmentServices
    {
        Task<Result> EnrollAsync(CreateEnrollmentRequest request);

        Task<Result> TakeDecisionAsync(int enrollmentId, EnrollmentDecisionRequest request);
    }
}
