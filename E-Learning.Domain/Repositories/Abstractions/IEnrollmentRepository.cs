using E_Learning.Domain.Entities;

namespace E_Learning.Domain.Repositories.Abstractions
{
    public interface IEnrollmentRepository : IGenaricRepository<Enrollment, int>
    {
        Task<List<Enrollment>> GetFilteredEnrollmentsAsync(int? LearnerId, int? CourseId, string? Status, DateTime? FromDate, DateTime? ToDate);
    }
}




