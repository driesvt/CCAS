using AutoMapper;
using CCAS.Application.DTOs.Instructor;
using CCAS.Application.DTOs.Instructor.Validators;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Instructors.Commands
{
    public class UpdateInstructorCommand : IRequest<Unit>
    {
        public InstructorDto InstructorDto { get; set; }
    }

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, Unit>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public UpdateInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstructorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InstructorDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var instructor = await _instructorRepository.Get(request.InstructorDto.Id);

            _mapper.Map(request.InstructorDto, instructor);

            await _instructorRepository.Update(instructor);

            return Unit.Value;
        }
    }
}
