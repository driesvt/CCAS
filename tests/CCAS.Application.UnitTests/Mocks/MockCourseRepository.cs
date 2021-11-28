using CCAS.Application.Interfaces.Persistence;
using CCAS.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.UnitTests.Mocks
{
    public static class MockCourseRepository
    {
        public static Mock<ICourseRepository> GetCourseRepository()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Title = "Mathematics",
                    Credits = 12
                },
                new Course
                {
                    Id = 2,
                    Title = "Biology",
                    Credits = 12
                },
                new Course
                {
                    Id = 3,
                    Title = "Physics",
                    Credits = 12
                }
            };

            var mockRepo = new Mock<ICourseRepository>();

            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(courses);

            mockRepo.Setup(x => x.Add(It.IsAny<Course>())).ReturnsAsync((Course course) =>
            {
                courses.Add(course);
                return course;
            });

            return mockRepo;
        }
    }
}
