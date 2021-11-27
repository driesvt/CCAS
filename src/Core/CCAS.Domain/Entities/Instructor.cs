using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Domain.Entities
{
    public class Instructor : Personnel
    {
        public ICollection<Course>? Courses { get; set; }
    }
}
