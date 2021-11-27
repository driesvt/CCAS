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
    public class GetInstructorDetailQuery : IRequest<InstructorDto>
    {
        public int Id { get; set; }
    }

    public class GetInstructorDetailQueryHandler : IRequestHandler<GetInstructorDetailQuery, InstructorDto>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public GetInstructorDetailQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }
        public async Task<InstructorDto> Handle(GetInstructorDetailQuery request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.Get(request.Id);
            return _mapper.Map<InstructorDto>(instructor);
        }
    }
}
