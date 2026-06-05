using E_Learning.BLL.Commons.ResponseResults;
using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.Services.Abstractions.Enrollment;
using E_Learning.Domain;
using Microsoft.AspNetCore.Authorization;

namespace E_Learning.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentServices _enrollmentServices;

        public EnrollmentsController(IEnrollmentServices enrollmentServices)
        {
            _enrollmentServices = enrollmentServices;
        }

        [HttpGet]
        [Authorize(Roles = $"{DefaultRoles.Admin},{DefaultRoles.Manager}")]
        public async Task<IActionResult> GetAll([FromQuery] int? learnerId, [FromQuery] int? courseId, [FromQuery] string? status, [FromQuery] DateOnly? fromDate, [FromQuery] DateOnly? toDate)
        {
            var result = await _enrollmentServices.GetAllAsync(learnerId, courseId, status, fromDate, toDate);

            return result.IsSuccess
                ? Ok(result.Value)
                : result.ToProblem();
        }

        [HttpPost]
        [Authorize(Roles = DefaultRoles.Learner)]
        public async Task<IActionResult> Enroll([FromBody] CreateEnrollmentRequest request)
        {
            var currentUserId = User.GetUserId();
            var result = await _enrollmentServices.EnrollAsync(request, currentUserId);
            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }


        [HttpPost("{id}/decision")]
        [Authorize(Roles = DefaultRoles.Manager)]
        public async Task<IActionResult> TakeDecision(int id, [FromBody] EnrollmentDecisionRequest request)
        {
            var result = await _enrollmentServices.TakeDecisionAsync(id, request);

            return result.IsSuccess
                ? Ok(new { Message = $"Enrollment decision '{request.Decision}' applied successfully" })
                : result.ToProblem();
        }
    }
}
