using HighSchoolSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem3.Application.ApplicationLogic
{
    public class Method
    {
        private HighSchoolSystemContext Context { get; set; }
        public Method()
        {
            Context = new();
        }

        public void GetStudentsByClass()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Nedan följer en översikt över alla klasser");
            Console.WriteLine("Välj en klass genom att skriva klassens ID och tryck Enter:");
            Console.ResetColor();

            var classes = from c in Context.Classes
                          select c;

            foreach (var c in classes)
            {
                Console.WriteLine($"Namn: {c.ClassName}, Klass-ID: {c.ClassId}");
            }

            string choice = Console.ReadLine();

            var students = Context.Students.Where(s => s.FkclassId.ToString() == choice).ToList();

            Console.WriteLine($"Alla elever i klass med Klass-ID: {choice}:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }

        public void GetAllGradesByMonth()
        {

            var result = Context.CourseLists
                .Include(cl => cl.Fkstudent)
                .Include(cl => cl.Fkcourse)
                .Where(cl => cl.SetDate <= new DateTime(2023, 12, 17) && cl.SetDate <= new DateTime(2023, 11, 17))
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"Elev: {item.Fkstudent.FirstName} {item.Fkstudent.LastName}, Kurs: {item.Fkcourse.CourseInfo}, Betyg: {item.GradeInfo}");
            }

        }

        public void GetCourses()
        {
            var query = from cl in Context.CourseLists
                        join c in Context.Courses on cl.FkcourseId equals c.CourseId
                        group cl by c.CourseInfo into g
                        select new
                        {
                            Kurs = g.Key,
                            Snittbetyg = g.Average(cl => Convert.ToDouble(cl.GradeInfo)),
                            HögstaBetyg = g.Max(cl => cl.GradeInfo),
                            LägstaBetyg = g.Min(cl => cl.GradeInfo)
                        }; 
            //var grades = Context.CourseLists
            //    .Include(cl => cl.Fkcourse)
            //    .ToList();
            //var gradeInfo = grades
            //    .Select(cl => new
            //    {
            //        Kurs = cl.Fkcourse.CourseInfo,
            //        Snittbetyg = cl.Fkcourse.CourseInfo.Average(cl => cl.GradeInfo),
            //        HögstaBetyg = grades.Max(cl => cl.GradeInfo),
            //        LägstaBetyg = grades.Min(cl => cl.GradeInfo)
            //    });


            foreach (var item in query)
            {
                Console.WriteLine($"Kurs: {item.Kurs} ; Snittbetyg: {item.Snittbetyg} ; Högsta betyg: {item.HögstaBetyg} ; Lägsta betyg: {item.LägstaBetyg}");
            }
        }

        public void AddNewStudent()
        {
            Console.WriteLine("Ange Elev-ID:");
            string studId = Console.ReadLine();
            int studentId = Int32.Parse(studId);
            Console.WriteLine("Ange förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Ange efternamn");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ange personnummer (YYYYMMDD-XXXX:");
            string personalNumber = Console.ReadLine();
            Console.WriteLine("Ange adress:");
            string address = Console.ReadLine();
            Console.WriteLine("Ange postnummer:");
            string zip = Console.ReadLine();
            Console.WriteLine("Ange Klass-ID:");
            string fkClId = Console.ReadLine();
            int fkClassId = Int32.Parse(fkClId);
            Console.Clear();

            var newStudent = new Student
            {
                StudentId = studentId,
                FirstName = firstName,
                LastName = lastName,
                PersonalNumber = personalNumber,
                Address = address,
                Zip = zip,
                FkclassId = fkClassId
            };
            Context.Students.Add(newStudent);

            Console.WriteLine("Ny elev har lagts till i databasen");

            Context.SaveChanges();
        }

        public void AddNewEmployee()
        {
            Console.WriteLine("Ange Anställnings-ID:");
            string empId = Console.ReadLine();
            int employeeId = Int32.Parse(empId);
            Console.WriteLine("Ange förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Ange efternamn");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ange titel (mr, ms, mrs):");
            string title = Console.ReadLine();
            Console.WriteLine("Ange anställningsdatum (YYYY-MM-DD:");
            string hDate = Console.ReadLine();
            DateTime hireDate = DateTime.Parse(hDate);
            Console.WriteLine("Ange födelsedatum (YYYY-MM-DD):");
            string bDate = Console.ReadLine();
            DateTime birthDate = DateTime.Parse(bDate);
            Console.WriteLine("Ange adress:");
            string address = Console.ReadLine();
            Console.WriteLine("Ange postnummer:");
            string zip = Console.ReadLine();
            Console.WriteLine("Ange befattnings-ID:");
            string fkProfId = Console.ReadLine();
            int fkProfessionId = Int32.Parse(fkProfId);
            Console.Clear();

            var newEmployee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                Title = title,
                HireDate = hireDate,
                BirthDate = birthDate,
                Address = address,
                Zip = zip,
                FkprofessionId = fkProfessionId
            };
            Context.Employees.Add(newEmployee);

            Console.WriteLine("Ny anställd har lagts till i databasen");

            Context.SaveChanges();
        }
    }
}
