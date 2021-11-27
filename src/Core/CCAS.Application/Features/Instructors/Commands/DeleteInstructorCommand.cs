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

namespace CCAS.Application.Features.Instructors.Commands
{
    public class DeleteInstructorCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public DeleteInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.Get(request.Id);

            if (instructor == null)
                throw new NotFoundException(nameof(Instructor), request.Id);

            await _instructorRepository.Delete(instructor);

            return Unit.Value;
        }
    }
}
