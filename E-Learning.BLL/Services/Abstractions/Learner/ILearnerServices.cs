

using E_Learning.BLL.DTOS.Learners.Request;
using E_Learning.BLL.DTOS.Learners.Response;

namespace E_Learning.BLL.Services.Abstractions.Learner
{
    public interface ILearnerServices
    {
        Task<Result<IEnumerable<GetAllLearnersResponse>>> GetAllAsync();
        Task<Result<GetLearnerByIdResponse>> GetByIdAsync(int Id);
        Task<Result> CreateAsync(CreateLearnerRequest request);
        Task<Result> UpdateAsync(int Id, UpdateLearnerRequest request);
        Task<Result> DeleteAsync(int Id);

    }
}
