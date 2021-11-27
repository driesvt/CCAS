using CCAS.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Enrollment.Validators
{
    public class IEnrollmentDtoValidator : AbstractValidator<IEnrollmentDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public IEnrollmentDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;

            RuleFor(p => p.CourseID)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var courseExists = await _courseRepository.Exists(id);
                    return !courseExists;
                })
                .WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.StudentID)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var studentExists = await _studentRepository.Exists(id);
                    return !studentExists;
                })
                .WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.Grade)
                .GreaterThan(1).WithMessage("{PropertyName} must be at least {ComparisonValue}")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }
    }
}
