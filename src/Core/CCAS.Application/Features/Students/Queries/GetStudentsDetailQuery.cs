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
    public class GetStudentDetailQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }

    public class GetStudentDetailQueryHandler : IRequestHandler<GetStudentDetailQuery, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentDetailQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentDetailQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.Get(request.Id);
            return _mapper.Map<StudentDto>(student);
        }
    }
}
