using AutoMapper;
using CCAS.Application.DTOs.Course;
using CCAS.Application.DTOs.Course.Validators;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces;
using CCAS.Application.Responses;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Courses.Commands
{
    public class CreateCourseCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseDto CreateCourseDto { get; set; }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, BaseCommandResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCourseDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var course = _mapper.Map<Course>(request.CreateCourseDto);

            course = await _courseRepository.Add(course);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = course.Id;
            return response;
        }
    }
}
