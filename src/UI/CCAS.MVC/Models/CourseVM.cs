using System.ComponentModel.DataAnnotations;

namespace CCAS.MVC.Models
{
    public class CourseVM : CreateCourseVM
    {
        public int Id { get; set; }
    }

    public class CreateCourseVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }

        //public ICollection<EnrollmentDto>? Enrollments { get; set; }
        //public ICollection<InstructorDto>? Instructors { get; set; }
    }
}
