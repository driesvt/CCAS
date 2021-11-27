using AutoMapper;
using CCAS.Application.DTOs.Enrollment;
using CCAS.Application.DTOs.Enrollment.Validators;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces.Persistence;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Enrollments.Commands
{
    public class UpdateEnrollmentCommand : IRequest<Unit>
    {
        public EnrollmentDto EnrollmentDto { get; set; }
    }

    public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, Unit>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public UpdateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository,
            ICourseRepository courseRepository,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEnrollmentDtoValidator(_courseRepository, _studentRepository);
            var validationResult = await validator.ValidateAsync(request.EnrollmentDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var enrollment = await _enrollmentRepository.Get(request.EnrollmentDto.Id);

            _mapper.Map(request.EnrollmentDto, enrollment);

            await _enrollmentRepository.Update(enrollment);

            return Unit.Value;
        }
    }
}
