using AutoMapper;
using CCAS.Application.DTOs.Instructor;
using CCAS.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Instructors.Queries
{
    public class GetInstructorQuery : IRequest<List<InstructorDto>>
    {
    }

    public class GetInstructorQueryHandler : IRequestHandler<GetInstructorQuery, List<InstructorDto>>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public GetInstructorQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }
        public async Task<List<InstructorDto>> Handle(GetInstructorQuery request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.GetAll();
            return _mapper.Map<List<InstructorDto>>(instructor);
        }
    }
}
