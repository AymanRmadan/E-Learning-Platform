namespace E_Learning.DAL.GenaricBase.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }



        public Task<int> SaveChangeAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

    }
}
