namespace E_Learning.DAL.GenaricBase.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IGenaricRepository<Course, int> _courses;
        private IGenaricRepository<Learner, int> _learners;
        private IGenaricRepository<Enrollment, int> _enrollments;
        private IGenaricRepository<AuditLog, int> _auditLogs;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        // ??= => for Lazy loading
        public IGenaricRepository<Course, int> Courses => _courses ??= new GenaricRepository<Course, int>(_dbContext);
        public IGenaricRepository<Learner, int> Learners => _learners ??= new GenaricRepository<Learner, int>(_dbContext);
        public IGenaricRepository<Enrollment, int> Enrollments => _enrollments ??= new GenaricRepository<Enrollment, int>(_dbContext);
        public IGenaricRepository<AuditLog, int> AuditLogs => _auditLogs ??= new GenaricRepository<AuditLog, int>(_dbContext);

        public Task<int> SaveChangeAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
