using AutoMapper;
using CCAS.Application.DTOs.Course;
using CCAS.Application.Features.Courses.Queries;
using CCAS.Application.Interfaces.Persistence;
using CCAS.Application.Profiles;
using CCAS.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CCAS.Application.UnitTests.Courses.Queries
{
    public class GetCoursesQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICourseRepository> _mockRepo;
        public GetCoursesQueryHandlerTests()
        {
            _mockRepo = MockCourseRepository.GetCourseRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCoursesQueryTest()
        {
            var handler = new GetCoursesQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCoursesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CourseDto>>();
        }
    }
}
