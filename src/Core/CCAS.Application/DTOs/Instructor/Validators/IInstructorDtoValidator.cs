using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Instructor.Validators
{
    public class IInstructorDtoValidator : AbstractValidator<IInstructorDto>
    {
        public IInstructorDtoValidator()
        {
            RuleFor(p => p.FirstMidName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(p => p.HireDate)
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be before {ComparisonValue}");
        }
    }
}
