using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftStudent
{
    public class Course
    {
        public string CourseName { get; set; }

        public Course(string courseName)
        {
            CourseName = courseName;
        }
    }
}
