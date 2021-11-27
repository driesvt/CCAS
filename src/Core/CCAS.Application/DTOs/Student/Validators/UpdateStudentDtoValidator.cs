using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Student.Validators
{
    public class UpdateStudentDtoValidator : AbstractValidator<StudentDto>
    {
        public UpdateStudentDtoValidator()
        {
            Include(new IStudentDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
