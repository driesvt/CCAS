using AutoMapper;
using CCAS.Application.DTOs.Instructor;
using CCAS.Application.DTOs.Instructor.Validators;
using CCAS.Application.Interfaces;
using CCAS.Application.Responses;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Instructors.Commands
{
    public class CreateInstructorCommand : IRequest<BaseCommandResponse>
    {
        public CreateInstructorDto CreateInstructorDto { get; set; }
    }

    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, BaseCommandResponse>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public CreateInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInstructorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateInstructorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var instructor = _mapper.Map<Instructor>(request.CreateInstructorDto);

            instructor = await _instructorRepository.Add(instructor);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = instructor.Id;
            return response;
        }
    }
}
