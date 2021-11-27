using CCAS.Application.DTOs.Common;
using CCAS.Application.DTOs.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.DTOs.Student
{
    public class CreateStudentDto : IStudentDto
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<EnrollmentDto>? Enrollments { get; set; }
    }
}
