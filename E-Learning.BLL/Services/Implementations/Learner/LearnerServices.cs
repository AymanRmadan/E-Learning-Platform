using E_Learning.BLL.DTOS.Learners.Request;
using E_Learning.BLL.DTOS.Learners.Response;
using E_Learning.BLL.Services.Abstractions.Learner;
using E_Learning.Domain.Repositories.Abstractions;

namespace E_Learning.BLL.Services.Implementations.Learner
{
    public class LearnerServices : ILearnerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public LearnerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> CreateAsync(CreateLearnerRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
                return Result.Failure(LearnerErrors.FullNameRequired);

            var isNationalIdExist = await _unitOfWork.Learners.AnyAsync(l => l.NationalId == request.NationalId);
            if (isNationalIdExist)
                return Result.Failure(LearnerErrors.NationalIdDuplicate);

            var learner = request.Adapt<Domain.Entities.Learner>();
            await _unitOfWork.Learners.InsertAsync(learner!);

            //Defualt value to avoid null Exception
            //  learner.UserId = "1";
            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }

        public async Task<Result<List<GetAllLearnersResponse>>> GetAllAsync()
        {
            var learners = await _unitOfWork.Learners.GetAllAsync();
            var response = learners.Adapt<List<GetAllLearnersResponse>>();
            return Result.Success(response!);
        }

        public async Task<Result<GetLearnerByIdResponse>> GetByIdAsync(int Id)
        {
            var learner = await _unitOfWork.Learners.GetByIdAsync(Id);
            if (learner == null)
                return Result.Failure<GetLearnerByIdResponse>(LearnerErrors.LearnerNotFound);

            var response = learner.Adapt<GetLearnerByIdResponse>();
            return Result.Success(response!);
        }

        public async Task<Result> UpdateAsync(int Id, UpdateLearnerRequest request)
        {
            var learner = await _unitOfWork.Learners.GetByIdAsync(Id);
            if (learner == null)
                return Result.Failure<GetLearnerByIdResponse>(LearnerErrors.LearnerNotFound);

            var isNationalIdExist = await _unitOfWork.Learners.AnyAsync(l => l.NationalId == request.NationalId && l.Id != Id);
            if (isNationalIdExist)
                return Result.Failure(LearnerErrors.NationalIdDuplicate);

            request.Adapt(learner);

            _unitOfWork.Learners.Update(learner);
            await _unitOfWork.SaveChangeAsync();
            return Result.Success();
        }


        public async Task<Result> DeleteAsync(int Id)
        {
            var learner = await _unitOfWork.Learners.GetByIdAsync(Id);
            if (learner == null)
                return Result.Failure<GetLearnerByIdResponse>(LearnerErrors.LearnerNotFound);

            _unitOfWork.Learners.Delete(learner);
            await _unitOfWork.SaveChangeAsync();

            return Result.Success(learner);
        }


    }



}
