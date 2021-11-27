using AutoMapper;
using CCAS.Application.DTOs.Enrollment;
using CCAS.Application.DTOs.Enrollment.Validators;
using CCAS.Application.Interfaces;
using CCAS.Application.Responses;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Enrollments.Commands
{
    public class CreateEnrollmentCommand : IRequest<BaseCommandResponse>
    {
        public CreateEnrollmentDto CreateEnrollmentDto { get; set; }
    }

    public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, BaseCommandResponse>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CreateEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, 
            ICourseRepository courseRepository, 
            IStudentRepository studentRepository, 
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEnrollmentDtoValidator(_courseRepository, _studentRepository);
            var validationResult = await validator.ValidateAsync(request.CreateEnrollmentDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var enrollment = _mapper.Map<Enrollment>(request.CreateEnrollmentDto);

            enrollment = await _enrollmentRepository.Add(enrollment);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = enrollment.Id;
            return response;
        }
    }
}
