using CCAS.Application.DTOs.Course;
using CCAS.Application.Features.Courses.Commands;
using CCAS.Application.Features.Courses.Queries;
using CCAS.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CCAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> Get()
        {
            var courses = await _mediator.Send(new GetCoursesQuery());
            return Ok(courses);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var course = await _mediator.Send(new GetCourseDetailQuery { Id = id });
            return Ok(course);
        }

        // POST api/<CoursesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseDto course)
        {
            var command = new CreateCourseCommand { CreateCourseDto = course };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CoursesController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CourseDto course)
        {
            var command = new UpdateCourseCommand { CourseDto = course };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
