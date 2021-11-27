using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Domain.Entities
{
    public class Course : BaseDomainEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
    }
}
