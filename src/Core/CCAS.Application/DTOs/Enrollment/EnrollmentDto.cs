using CCAS.Application.DTOs.Common;
using CCAS.Application.DTOs.Course;
using CCAS.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Enrollment
{
    public class EnrollmentDto : BaseDto, IEnrollmentDto
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int? Grade { get; set; }

        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
    }
}
