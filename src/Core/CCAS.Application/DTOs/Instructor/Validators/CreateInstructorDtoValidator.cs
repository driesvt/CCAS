using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Instructor.Validators
{
    public class CreateInstructorDtoValidator : AbstractValidator<CreateInstructorDto>
    {
        public CreateInstructorDtoValidator()
        {
            Include(new IInstructorDtoValidator());
        }
    }
}
