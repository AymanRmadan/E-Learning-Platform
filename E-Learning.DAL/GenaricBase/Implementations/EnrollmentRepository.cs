using E_Learning.Domain.Enums;

namespace E_Learning.DAL.GenaricBase.Implementations
{
    public class EnrollmentRepository : GenaricRepository<Enrollment, int>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Enrollment>> GetFilteredEnrollmentsAsync(int? LearnerId, int? CourseId, string? Status, DateTime? FromDate, DateTime? ToDate)
        {

            var query = _table
                .Include(e => e.Learner)
                .Include(e => e.Course)
                .AsNoTracking();


            if (LearnerId.HasValue)
                query = query.Where(e => e.LearnerId == LearnerId.Value);

            if (CourseId.HasValue)
                query = query.Where(e => e.CourseId == CourseId.Value);

            if (FromDate.HasValue)
                query = query.Where(e => e.EnrollmentDate >= FromDate.Value.Date);

            if (ToDate.HasValue)
            {
                var nextDay = ToDate.Value.Date.AddDays(1);
                query = query.Where(e => e.EnrollmentDate < nextDay);
            }

            if (!string.IsNullOrWhiteSpace(Status) &&
            Enum.TryParse<EnrollmentStatus>(Status, true, out var parsedStatus))
            {
                query = query.Where(e => e.Status == parsedStatus);
            }


            return await query
                .OrderByDescending(e => e.EnrollmentDate)
                .ToListAsync();


        }
    }

}