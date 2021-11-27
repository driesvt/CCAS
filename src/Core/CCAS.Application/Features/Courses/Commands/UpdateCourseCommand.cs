using AutoMapper;
using CCAS.Application.DTOs.Course;
using CCAS.Application.DTOs.Course.Validators;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<Unit>
    {
        public CourseDto CourseDto { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var course = await _courseRepository.Get(request.CourseDto.Id);

            _mapper.Map(request.CourseDto, course);

            await _courseRepository.Update(course);

            return Unit.Value;
        }
    }
}
