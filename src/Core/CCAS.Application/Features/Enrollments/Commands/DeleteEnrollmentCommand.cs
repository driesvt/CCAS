using AutoMapper;
using CCAS.Application.Exceptions;
using CCAS.Application.Interfaces.Persistence;
using CCAS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Enrollments.Commands
{
    public class DeleteEnrollmentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public DeleteEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentRepository.Get(request.Id);

            if (enrollment == null)
                throw new NotFoundException(nameof(Enrollment), request.Id);

            await _enrollmentRepository.Delete(enrollment);

            return Unit.Value;
        }
    }
}
