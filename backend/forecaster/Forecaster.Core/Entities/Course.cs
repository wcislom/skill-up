using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecaster.Core.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }
}
