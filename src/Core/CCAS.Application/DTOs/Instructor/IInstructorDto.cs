using CCAS.Application.DTOs.Course;

namespace CCAS.Application.DTOs.Instructor
{
    public interface IInstructorDto
    {
        ICollection<CourseDto>? Courses { get; set; }
        string FirstMidName { get; set; }
        string FullName { get; }
        DateTime HireDate { get; set; }
        string LastName { get; set; }
    }
}