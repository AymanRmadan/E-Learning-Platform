

using E_Learning.Domain.Entities;

namespace E_Learning.Domain.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        IGenaricRepository<Course, int> Courses { get; }
        IGenaricRepository<Learner, int> Learners { get; }
        IGenaricRepository<Enrollment, int> Enrollments { get; }
        IGenaricRepository<AuditLog, int> AuditLogs { get; }


        Task<int> SaveChangeAsync();
    }
}
