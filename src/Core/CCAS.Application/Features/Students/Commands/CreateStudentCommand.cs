using AutoMapper;
using CCAS.Application.DTOs.Student;
using CCAS.Application.DTOs.Student.Validators;
using CCAS.Application.Interfaces;
using CCAS.Application.Responses;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Students.Commands
{
    public class CreateStudentCommand : IRequest<BaseCommandResponse>
    {
        public CreateStudentDto CreateStudentDto { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, BaseCommandResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateStudentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateStudentDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var student = _mapper.Map<Student>(request.CreateStudentDto);

            student = await _studentRepository.Add(student);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = student.Id;
            return response;
        }
    }
}
