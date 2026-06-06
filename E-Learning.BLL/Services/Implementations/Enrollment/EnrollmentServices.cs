using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Response;
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

        public async Task<Result<IReadOnlyList<EnrollmentResponse>>> GetAllAsync(EnrollmentFilterRequest request)
        {
            var enrollments = await _unitOfWork.Enrollments.
                                GetFilteredEnrollmentsAsync(
                                            request.LearnerId,
                                            request.CourseId,
                                            request.Status,
                                            request.FromDate,
                                            request.ToDate
                                            );

            var response = enrollments.Select(e => new EnrollmentResponse(
                e.Id,
                e.EnrollmentDate,
                e.Status.ToString(),
                e.DecisionDate,
                e.RejectionReason,
                new LearnerInfo(e.Learner.Id, e.Learner.FullName, e.Learner.Email),
                new CourseInfo(e.Course.Id, e.Course.Title, e.Course.DurationHours)
            )).ToList();

            return Result.Success<IReadOnlyList<EnrollmentResponse>>(response);



        }


        public async Task<Result> EnrollAsync(CreateEnrollmentRequest request, int userId)
        {
            var learner = await _unitOfWork.Learners.FirstOrDefaultAsync(l => l.UserId == userId);
            if (learner == null)
            {
                return Result.Failure(LearnerErrors.LearnerNotFound);
            }

            var isCourseExist = await _unitOfWork.Courses.GetByIdAsync(request.CourseId);
            if (isCourseExist == null)
                return Result.Failure(EnrollmentErrors.CourseNotFound);

            if (!isCourseExist.IsActive)
                return Result.Failure(EnrollmentErrors.InactiveCourse);

            var isAlreadyEnrolled = await _unitOfWork.Enrollments
            .AnyAsync(e => e.Learner.UserId == learner.UserId && e.CourseId == request.CourseId);

            if (isAlreadyEnrolled)
                return Result.Failure(EnrollmentErrors.AlreadyEnrolled);

            var courseStatus = isCourseExist.RequiresApproval
            ? EnrollmentStatus.PendingApproval
            : EnrollmentStatus.Approved;


            var enrollment = new Domain.Entities.Enrollment
            {
                LearnerId = learner.Id,
                CourseId = request.CourseId,
                Status = courseStatus,
                EnrollmentDate = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            await _unitOfWork.Enrollments.InsertAsync(enrollment);
            await _unitOfWork.SaveChangeAsync();

            var auditLog = new AuditLog
            {
                EntityName = nameof(Domain.Entities.Enrollment),
                EntityId = enrollment.Id,
                Action = "INSERT ACTION",
                OldValue = string.Empty,
                NewValue = JsonSerializer.Serialize(new { userId, request.CourseId, Status = courseStatus.ToString() }),
                PerformedBy = learner.FullName,
                PerformedAt = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            await _unitOfWork.AuditLogs.InsertAsync(auditLog);
            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }


        public async Task<Result> TakeDecisionAsync(int enrollmentId, EnrollmentDecisionRequest request)
        {
            var enrollment = await _unitOfWork.Enrollments.GetByIdAsync(enrollmentId);
            if (enrollment == null)
                return Result.Failure(ApprovalErrors.EnrollmentNotFound);

            if (enrollment.Status != EnrollmentStatus.PendingApproval)
                return Result.Failure(ApprovalErrors.InvalidStatusForDecision);

            string oldStatus = enrollment.Status.ToString();

            if (string.Equals(request.Decision.Trim().ToLower(), "Approved", StringComparison.OrdinalIgnoreCase))
            {
                enrollment.Status = EnrollmentStatus.Approved;
            }
            else if (string.Equals(request.Decision.Trim().ToLower(), "Rejected", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(request.Reason))
                    return Result.Failure(ApprovalErrors.RejectionReasonRequired);

                enrollment.Status = EnrollmentStatus.Rejected;
                enrollment.RejectionReason = request.Reason;
            }
            else
            {
                return Result.Failure(ApprovalErrors.InvalidStatusForDecision);
            }

            enrollment.DecisionDate = DateOnly.FromDateTime(DateTime.UtcNow);

            _unitOfWork.Enrollments.Update(enrollment);

            var auditLog = new AuditLog
            {
                EntityName = nameof(Domain.Entities.Enrollment),
                EntityId = enrollment.Id,
                Action = $"UPDATE ACTION _{enrollment.Status.ToString().ToUpper()}",
                OldValue = oldStatus,
                NewValue = enrollment.Status.ToString(),
                PerformedBy = "Manager",
                PerformedAt = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            await _unitOfWork.AuditLogs.InsertAsync(auditLog);
            await _unitOfWork.SaveChangeAsync();

            return Result.Success();
        }
    }
}
