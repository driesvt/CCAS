using AutoMapper;
using CCAS.MVC.Interfaces;
using CCAS.MVC.Models;
using CCAS.MVC.Services.Base;

namespace CCAS.MVC.Services
{
    public class CourseService : BaseHttpService, ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;
        private readonly ILocalStorageService _localStorageService;

        public CourseService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            _mapper = mapper;
            _httpclient = httpclient;
            _localStorageService = localStorageService;
        }
        public async Task<Response<int>> CreateCourse(CreateCourseVM course)
        {
            try
            {
                var response = new Response<int>();
                CreateCourseDto createCourse = _mapper.Map<CreateCourseDto>(course);
                var apiResponse = await _client.CoursesPOSTAsync(createCourse);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteCourse(int id)
        {
            try
            {
                AddBearerToken();
                await _client.CoursesDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<CourseVM> GetCourseDetails(int id)
        {
            var course = await _client.CoursesGETAsync(id);
            return _mapper.Map<CourseVM>(course);
        }

        public async Task<List<CourseVM>> GetCourses()
        {
            var courses = await _client.CoursesAllAsync();
            return _mapper.Map<List<CourseVM>>(courses);
        }

        public async Task<Response<int>> UpdateCourse(int id, CourseVM course)
        {
            try
            {
                CourseDto courseDto = _mapper.Map<CourseDto>(course);
                await _client.CoursesPUTAsync(courseDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
