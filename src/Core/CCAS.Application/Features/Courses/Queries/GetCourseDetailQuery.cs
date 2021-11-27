using AutoMapper;
using CCAS.Application.DTOs.Course;
using CCAS.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Courses.Queries
{
    public class GetCourseDetailQuery : IRequest<CourseDto>
    {
        public int Id { get; set; }
    }

    public class GetCourseDetailQueryHandler : IRequestHandler<GetCourseDetailQuery, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseDetailQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseDto> Handle(GetCourseDetailQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.Get(request.Id);
            return _mapper.Map<CourseDto>(course);
        }
    }
}
