using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UppgiftLINQ.ProductOrder;

namespace UppgiftLINQ.StudentGrades
{
    public class Grading
    {
        public void RunGrading()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name = "Clara",
                    Results = new List<CourseResult>
                    {
                        new CourseResult { CourseName = "Math", Grade = 85 },
                        new CourseResult { CourseName = "English", Grade = 90 }
                    }
                },
                new Student
                {
                    Name = "David",
                    Results = new List<CourseResult>
                    {
                        new CourseResult { CourseName = "Math", Grade = 70 },
                        new CourseResult { CourseName = "English", Grade = 65 }
                    }
                }
            };

            //- []  Filtrera elever med godkänt i alla kurser(`All`)
            Console.WriteLine("\nStudents with above 70 grade score in all courses:");
            var passingStudents = students.Where(s => s.Results.All(g => g.Grade >= 70));
            foreach(var ps in passingStudents)
            {
                Console.WriteLine($"{ps.Name}");
            }

            //- []  Hämta elever med högst betyg i “Math” (`Where` + `Max`)
            Console.WriteLine("\nStudent with highest grade score in math:");
            var highestMathScore = students.Max(s => s.Results.FirstOrDefault(c => c.CourseName == "Math").Grade);
            var mathGenius = students.Where(s => s.Results.First(c => c.CourseName == "Math").Grade == highestMathScore);
            foreach (var ps in mathGenius)
            {
                Console.WriteLine($"{ps.Name}");
            }

            //- []  Projicera elevnamn och medelbetyg(`Select`)
            Console.WriteLine("\nStudents average grade:");
            var studentAverageGrades = students.Select(s => new { s.Name, AverageGrade = s.Results.Select(g => g.Grade).Average() });
            foreach(var student in studentAverageGrades)
            {
                Console.WriteLine($"{student.Name}: {student.AverageGrade}");
            }

            //- []  Sortera elever efter medelbetyg(`OrderBy`)
            Console.WriteLine("\nSorted by average grade:");
            var orderedByGrade = studentAverageGrades.OrderBy(ag => ag.AverageGrade);
            foreach (var student in orderedByGrade)
            {
                Console.WriteLine($"{student.Name}: {student.AverageGrade}");
            }

            //- []  Gruppera resultat per kurs och visa snittbetyg(`GroupBy` + `Average`)
            Console.WriteLine("\nGrouped result per course with grade:");
            var groupedResult = studentAverageGrades.OrderBy(ag => ag.AverageGrade);
            foreach (var student in orderedByGrade)
            {
                Console.WriteLine($"{student.Name}: {student.AverageGrade}");
            }

            //- []  Hämta första elev med betyg under 70 i “English” (`Where` + `FirstOrDefault`)
            Console.WriteLine("\nFirst student with english grade below 70:");
            Console.WriteLine("1:");
            var englishStudent = students.FirstOrDefault(s => s.Results.Any(c => c.CourseName == "English" && c.Grade < 70));
            Console.WriteLine(englishStudent != null ? englishStudent.Name : "Student not found.");

            Console.WriteLine("2:");
            var english = students.Where(s => s.Results.Any(c => c.CourseName == "English" && c.Grade < 70));
            var firstEnglist = english.FirstOrDefault();
            Console.WriteLine(firstEnglist != null ? firstEnglist.Name : "Student not found.");
        }
    }
}
