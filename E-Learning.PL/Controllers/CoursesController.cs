using E_Learning.BLL.Commons.ResponseResults;
using E_Learning.BLL.DTOS.Courses.Request;
using E_Learning.BLL.Services.Abstractions.Course;

namespace E_Learning.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseServices _courseServices;

        public CoursesController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseServices.Get();
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _courseServices.GetById(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
        {
            var result = await _courseServices.Create(request);
            return result.IsSuccess ? Ok(new { Message = "Course Created Successfully" }) : result.ToProblem();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseRequest request)
        {
            var result = await _courseServices.Update(id, request);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseServices.Delete(id);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }
    }
}