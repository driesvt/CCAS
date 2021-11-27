using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Course.Validators
{
    public class ICourseDtoValidator : AbstractValidator<ICourseDto>
    {
        public ICourseDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(p => p.Credits)
                .GreaterThan(1).WithMessage("{PropertyName} must be at least {ComparisonValue}")
                .LessThan(15).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }
    }
}
