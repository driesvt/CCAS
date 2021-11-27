using CCAS.Application.DTOs.Common;
using CCAS.Application.DTOs.Enrollment;
using CCAS.Application.DTOs.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Course
{
    public class CourseDto : BaseDto, ICourseDto
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<EnrollmentDto>? Enrollments { get; set; }
        public ICollection<InstructorDto>? Instructors { get; set; }
    }
}
