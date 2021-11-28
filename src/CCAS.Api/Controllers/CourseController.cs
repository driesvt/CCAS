using CCAS.Application.DTOs.Course;
using CCAS.Application.Features.Courses.Commands;
using CCAS.Application.Features.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CCAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> Get()
        {
            var courses = await _mediator.Send(new GetCoursesQuery());
            return Ok(courses);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var course = await _mediator.Send(new GetCourseDetailQuery {Id = id });
            return Ok(course);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCourseDto course)
        {
            var command = new CreateCourseCommand { CreateCourseDto = course };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CourseController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CourseDto course)
        {
            var command = new UpdateCourseCommand { CourseDto = course };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
