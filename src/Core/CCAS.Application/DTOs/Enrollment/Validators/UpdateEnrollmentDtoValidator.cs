using CCAS.Application.Interfaces.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Enrollment.Validators
{
    public class UpdateEnrollmentDtoValidator : AbstractValidator<EnrollmentDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public UpdateEnrollmentDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;

            Include(new IEnrollmentDtoValidator(_courseRepository, _studentRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
