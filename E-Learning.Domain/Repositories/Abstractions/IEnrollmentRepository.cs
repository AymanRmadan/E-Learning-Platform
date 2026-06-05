using E_Learning.Domain.Entities;

namespace E_Learning.Domain.Repositories.Abstractions
{
    public interface IEnrollmentRepository : IGenaricRepository<Enrollment, int>
    {
        Task<List<Enrollment>> GetFilteredEnrollmentsAsync(
            int? learnerId,
            int? courseId,
            string? status,
            DateOnly? fromDate,
            DateOnly? toDate);
    }
}




