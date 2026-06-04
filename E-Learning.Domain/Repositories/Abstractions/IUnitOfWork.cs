

namespace E_Learning.Domain.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        // ITestRepository TestRepository { get; }



        Task<int> SaveChangeAsync();
    }
}
