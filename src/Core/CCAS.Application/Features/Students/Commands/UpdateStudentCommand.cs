using AutoMapper;
using CCAS.Application.DTOs.Student;
using CCAS.Application.DTOs.Student.Validators;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Students.Commands
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public StudentDto StudentDto { get; set; }
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStudentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.StudentDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var student = await _studentRepository.Get(request.StudentDto.Id);

            _mapper.Map(request.StudentDto, student);

            await _studentRepository.Update(student);

            return Unit.Value;
        }
    }
}
