using AutoMapper;
using CCAS.MVC.Models;
using CCAS.MVC.Services.Base;

namespace CCAS.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCourseDto, CreateCourseVM>().ReverseMap();
            CreateMap<CourseDto, CourseVM>().ReverseMap();
        }
    }
}
