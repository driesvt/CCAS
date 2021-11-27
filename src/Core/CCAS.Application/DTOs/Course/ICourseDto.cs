
using CCAS.Application.DTOs.Enrollment;
using CCAS.Application.DTOs.Instructor;

namespace CCAS.Application.DTOs.Course
{
    public interface ICourseDto
    {
        int Credits { get; set; }
        ICollection<EnrollmentDto>? Enrollments { get; set; }
        ICollection<InstructorDto>? Instructors { get; set; }
        string Title { get; set; }
    }
}