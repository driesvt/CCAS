using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Course.Validators
{
    public class UpdateCourseDtoValidator : AbstractValidator<CourseDto>
    {
        public UpdateCourseDtoValidator()
        {
            Include(new ICourseDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
