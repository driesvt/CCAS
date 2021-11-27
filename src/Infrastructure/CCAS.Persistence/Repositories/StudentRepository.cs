using CCAS.Application.Interfaces.Persistence;
using CCAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Persistence.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly CCASDbContext _dbContext;

        public StudentRepository(CCASDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
