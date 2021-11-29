using AutoMapper;
using CCAS.Application.DTOs.Course;
using CCAS.Application.Exceptions;
using CCAS.Application.Features.Courses.Commands;
using CCAS.Application.Interfaces.Persistence;
using CCAS.Application.Profiles;
using CCAS.Application.Responses;
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

namespace CCAS.Application.UnitTests.Courses.Commands
{
    public class CreateCourseCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICourseRepository> _mockRepo;
        private readonly CreateCourseDto _courseDto;
        private readonly CreateCourseCommandHandler _handler;
        public CreateCourseCommandHandlerTests()
        {
            _mockRepo = MockCourseRepository.GetCourseRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCourseCommandHandler(_mockRepo.Object, _mapper);
            _courseDto = new CreateCourseDto
            {
                Title = "Test DTO",
                Credits = 12
            };
        }

        [Fact]
        public async Task CreateCourseTest()
        {
            var result = await _handler.Handle(new CreateCourseCommand() { CreateCourseDto = _courseDto }, CancellationToken.None);

            var courses = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            courses.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InvalidCreateCourseTest()
        {
            _courseDto.Credits = -2;

            var result = await _handler.Handle(new CreateCourseCommand() { CreateCourseDto = _courseDto }, CancellationToken.None);

            var courses = await _mockRepo.Object.GetAll();

            courses.Count.ShouldBe(3);
            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}
