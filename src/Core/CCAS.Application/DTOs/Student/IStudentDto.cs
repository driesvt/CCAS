using CCAS.Application.DTOs.Enrollment;

namespace CCAS.Application.DTOs.Student
{
    public interface IStudentDto
    {
        DateTime EnrollmentDate { get; set; }
        ICollection<EnrollmentDto>? Enrollments { get; set; }
        string FirstMidName { get; set; }
        string FullName { get; }
        string LastName { get; set; }
    }
}