

using E_Learning.BLL.DTOS.Learners.Request;
using E_Learning.BLL.DTOS.Learners.Response;

namespace E_Learning.BLL.Services.Abstractions.Learner
{
    public interface ILearnerServices
    {
        Task<Result<List<GetAllLearnersResponse>>> Get();
        Task<Result<GetLearnerByIdResponse>> GetById(int Id);
        Task<Result> Create(CreateLearnerRequest request);
        Task<Result> Update(int Id, UpdateLearnerRequest request);
        Task<Result> Delete(int Id);
    }
}
