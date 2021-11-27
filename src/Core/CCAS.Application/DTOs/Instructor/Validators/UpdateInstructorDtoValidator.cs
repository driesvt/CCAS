using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Instructor.Validators
{
    public class UpdateInstructorDtoValidator : AbstractValidator<InstructorDto>
    {
        public UpdateInstructorDtoValidator()
        {
            Include(new IInstructorDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
