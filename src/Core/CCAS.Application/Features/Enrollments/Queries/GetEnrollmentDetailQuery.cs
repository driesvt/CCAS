using AutoMapper;
using CCAS.Application.DTOs.Enrollment;
using CCAS.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Enrollments.Queries
{
    public class GetEnrollmentDetailQuery : IRequest<EnrollmentDto>
    {
        public int Id { get; set; }
    }

    public class GetEnrollmentDetailQueryHandler : IRequestHandler<GetEnrollmentDetailQuery, EnrollmentDto>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public GetEnrollmentDetailQueryHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }
        public async Task<EnrollmentDto> Handle(GetEnrollmentDetailQuery request, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentRepository.Get(request.Id);
            return _mapper.Map<EnrollmentDto>(enrollment);
        }
    }
}
