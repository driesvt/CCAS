using CCAS.Application.DTOs.Course;
using CCAS.Application.DTOs.Student;

namespace CCAS.Application.DTOs.Enrollment
{
    public interface IEnrollmentDto
    {
        CourseDto Course { get; set; }
        int CourseID { get; set; }
        int? Grade { get; set; }
        StudentDto Student { get; set; }
        int StudentID { get; set; }
    }
}