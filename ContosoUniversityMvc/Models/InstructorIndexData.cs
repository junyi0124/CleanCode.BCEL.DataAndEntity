using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversityMvc.Models
{
    public class InstructorIndexData
    {
        //public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Instructor> Instructors { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
