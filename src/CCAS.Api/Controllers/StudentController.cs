using CCAS.Application.DTOs.Student;
using CCAS.Application.Features.Students.Commands;
using CCAS.Application.Features.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CCAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> Get()
        {
            var students = await _mediator.Send(new GetStudentsQuery());
            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var student = await _mediator.Send(new GetStudentDetailQuery {Id = id });
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateStudentDto student)
        {
            var command = new CreateStudentCommand { CreateStudentDto = student };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<StudentController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] StudentDto student)
        {
            var command = new UpdateStudentCommand { StudentDto = student };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteStudentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
