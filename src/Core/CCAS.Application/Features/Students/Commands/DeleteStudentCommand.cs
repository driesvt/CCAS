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

namespace CCAS.Application.Features.Students.Commands
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.Get(request.Id);

            if (student == null)
                throw new NotFoundException(nameof(Student), request.Id);

            await _studentRepository.Delete(student);

            return Unit.Value;
        }
    }
}
