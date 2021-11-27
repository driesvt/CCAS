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
    public class GetEnrollmentsQuery : IRequest<List<EnrollmentDto>>
    {
    }

    public class GetEnrollmentsQueryHandler : IRequestHandler<GetEnrollmentsQuery, List<EnrollmentDto>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public GetEnrollmentsQueryHandler(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }
        public async Task<List<EnrollmentDto>> Handle(GetEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            var enrollments = await _enrollmentRepository.GetAll();
            return _mapper.Map<List<EnrollmentDto>>(enrollments);
        }
    }
}
