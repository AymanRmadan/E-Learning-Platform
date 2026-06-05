using E_Learning.BLL.Commons.ResponseResults;
using E_Learning.BLL.DTOS.Learners.Request;
using E_Learning.BLL.Services.Abstractions.Learner;

namespace E_Learning.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnersController : ControllerBase
    {
        private readonly ILearnerServices _learnerServices;

        public LearnersController(ILearnerServices learnerServices)
        {
            _learnerServices = learnerServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _learnerServices.Get();
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _learnerServices.GetById(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLearnerRequest request)
        {
            var result = await _learnerServices.Create(request);
            return result.IsSuccess ? Ok(new { Message = "Learner Created Successfully" }) : result.ToProblem();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLearnerRequest request)
        {
            var result = await _learnerServices.Update(id, request);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _learnerServices.Delete(id);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }
    }
}
