using CCAS.Application.DTOs.Enrollment;
using CCAS.Application.Features.Enrollments.Commands;
using CCAS.Application.Features.Enrollments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CCAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EnrollmentsController>
        [HttpGet]
        public async Task<ActionResult<List<EnrollmentDto>>> Get()
        {
            var enrollments = await _mediator.Send(new GetEnrollmentsQuery());
            return Ok(enrollments);
        }

        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> Get(int id)
        {
            var enrollment = await _mediator.Send(new GetEnrollmentDetailQuery { Id = id });
            return Ok(enrollment);
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateEnrollmentDto enrollment)
        {
            var command = new CreateEnrollmentCommand { CreateEnrollmentDto = enrollment };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<EnrollmentsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EnrollmentDto enrollment)
        {
            var command = new UpdateEnrollmentCommand { EnrollmentDto = enrollment };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<EnrollmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEnrollmentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
