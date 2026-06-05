using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.Services.Abstractions.Enrollment;
using E_Learning.Domain.Entities;
using E_Learning.Domain.Enums;
using E_Learning.Domain.Repositories.Abstractions;
using System.Text.Json;

namespace E_Learning.BLL.Services.Implementations.Enrollment
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> EnrollAsync(CreateEnrollmentRequest request)
        {
            var isLearnerExist = await _unitOfWork.Learners.AnyAsync(l => l.Id == request.LearnerId);
            if (!isLearnerExist)
                return Result.Failure(EnrollmentErrors.LearnerNotFound);

            var isCourseExist = await _unitOfWork.Courses.GetByIdAsync(request.CourseId);
            if (isCourseExist == null)
                return Result.Failure(EnrollmentErrors.CourseNotFound);

            if (!isCourseExist.IsActive)
                return Result.Failure(EnrollmentErrors.InactiveCourse);

            var isAlreadyEnrolled = await _unitOfWork.Enrollments
            .AnyAsync(e => e.LearnerId == request.LearnerId && e.CourseId == request.CourseId);

            if (isAlreadyEnrolled)
                return Result.Failure(EnrollmentErrors.AlreadyEnrolled);

            var courseStatus = isCourseExist.RequiresApproval
            ? EnrollmentStatus.PendingApproval
            : EnrollmentStatus.Approved;


            var enrollment = new Domain.Entities.Enrollment
            {
                LearnerId = request.LearnerId,
                CourseId = request.CourseId,
                Status = courseStatus,
                EnrollmentDate = DateTime.UtcNow
            };

            await _unitOfWork.Enrollments.InsertAsync(enrollment);

            var auditLog = new AuditLog
            {
                EntityName = nameof(Domain.Entities.Enrollment),
                EntityId = enrollment.Id,
                Action = "INSERT_ENROLLMENT",
                OldValue = string.Empty,
                NewValue = JsonSerializer.Serialize(new { request.LearnerId, request.CourseId, Status = courseStatus.ToString() }),
                PerformedBy = "System_User",
                PerformedAt = DateTime.UtcNow
            };

            await _unitOfWork.AuditLogs.InsertAsync(auditLog);
            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
