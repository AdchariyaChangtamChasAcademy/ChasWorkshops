using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftStudent
{
    public class Student
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Student(string name)
        {
            Name = name;
            Courses = new List<Course>();
        }

        public void PrintCourses()
        {
            foreach (var course in Courses)
            {
                Console.WriteLine();
            }
        }
    }
}
