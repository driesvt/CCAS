using AutoMapper;
using CCAS.Application.DTOs.Student;
using CCAS.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Application.Features.Students.Queries
{
    public class GetStudentsQuery : IRequest<List<StudentDto>>
    {
    }

    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var courses = await _studentRepository.GetAll();
            return _mapper.Map<List<StudentDto>>(courses);
        }
    }
}
