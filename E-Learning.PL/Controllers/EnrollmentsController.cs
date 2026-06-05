using E_Learning.BLL.Commons.ResponseResults;
using E_Learning.BLL.DTOS.Enrollments.E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.DTOS.Enrollments.Request;
using E_Learning.BLL.Services.Abstractions.Enrollment;

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
        public async Task<IActionResult> GetAll([FromQuery] int? LearnerId, int? CourseId, string? Status, DateTime? FromDate, DateTime? ToDate)
        {
            var result = await _enrollmentServices.GetAllAsync(LearnerId, CourseId, Status, FromDate, ToDate);

            return result.IsSuccess
                ? Ok(result.Value)
                : result.ToProblem();
        }

        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] CreateEnrollmentRequest request)
        {
            var result = await _enrollmentServices.EnrollAsync(request);

            return result.IsSuccess
                ? Ok(new { Message = "Enrollment request processed successfully." })
                : result.ToProblem();
        }


        [HttpPost("{id}/decision")]
        public async Task<IActionResult> TakeDecision(int id, [FromBody] EnrollmentDecisionRequest request)
        {
            var result = await _enrollmentServices.TakeDecisionAsync(id, request);

            return result.IsSuccess
                ? Ok(new { Message = $"Enrollment decision '{request.Decision}' applied successfully" })
                : result.ToProblem();
        }
    }
}
