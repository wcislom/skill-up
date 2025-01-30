using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecaster.Core.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; } = new Student();
        public Course Course { get; set; } = new Course();
    }

    public enum Grade
    {
        A, B, C, D, F
    }
}
