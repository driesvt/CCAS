using CCAS.MVC.Models;
using CCAS.MVC.Services.Base;

namespace CCAS.MVC.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseVM>> GetCourses();
        Task<CourseVM> GetCourseDetails(int id);
        Task<Response<int>> CreateCourse(CreateCourseVM course);
        Task<Response<int>> UpdateCourse(int id, CourseVM course);
        Task<Response<int>> DeleteCourse(int id);
    }
}
