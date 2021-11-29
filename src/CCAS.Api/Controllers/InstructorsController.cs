using CCAS.Application.DTOs.Instructor;
using CCAS.Application.Features.Instructors.Commands;
using CCAS.Application.Features.Instructors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CCAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstructorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<InstructorsController>
        [HttpGet]
        public async Task<ActionResult<List<InstructorDto>>> Get()
        {
            var instructors = await _mediator.Send(new GetInstructorQuery());
            return Ok(instructors);
        }

        // GET api/<InstructorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDto>> Get(int id)
        {
            var instructor = await _mediator.Send(new GetInstructorDetailQuery { Id = id });
            return Ok(instructor);
        }

        // POST api/<InstructorsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateInstructorDto instructor)
        {
            var command = new CreateInstructorCommand { CreateInstructorDto = instructor };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<InstructorsController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] InstructorDto instructor)
        {
            var command = new UpdateInstructorCommand { InstructorDto = instructor };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<InstructorsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteInstructorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
