using AutoMapper;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.Get(request.Id);

            if (course == null)
                throw new NotFoundException(nameof(Course), request.Id);

            await _courseRepository.Delete(course);

            return Unit.Value;
        }
    }
}
