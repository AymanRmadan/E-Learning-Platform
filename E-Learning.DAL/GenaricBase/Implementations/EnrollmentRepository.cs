using E_Learning.Domain.Enums;

namespace E_Learning.DAL.GenaricBase.Implementations
{
    public class EnrollmentRepository : GenaricRepository<Enrollment, int>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Enrollment>> GetFilteredEnrollmentsAsync(
                int? learnerId, int? courseId, string? status, DateOnly? fromDate, DateOnly? toDate)
        {

            var query = _table
                .Include(e => e.Learner)
                .Include(e => e.Course)
                .AsNoTracking();


            if (learnerId.HasValue)
                query = query.Where(e => e.LearnerId == learnerId.Value);

            if (courseId.HasValue)
                query = query.Where(e => e.CourseId == courseId.Value);

            if (fromDate.HasValue)
                query = query.Where(e => e.EnrollmentDate >= fromDate.Value);

            if (toDate.HasValue)
            {
                query = query.Where(e => e.EnrollmentDate <= toDate.Value);
            }

            if (!string.IsNullOrWhiteSpace(status) &&
            Enum.TryParse<EnrollmentStatus>(status, true, out var parsedStatus))
            {
                query = query.Where(e => e.Status == parsedStatus);
            }


            return await query
                .OrderByDescending(e => e.EnrollmentDate)
                .ToListAsync();


        }
    }

}