using EFCoreConsole.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0. Query
            // GetData();

            // 1. Add
            // AddData();

            // 2. Update
            UpdateData();

            // 3. Delete
            // DeleteData();

        }

        private static void GetData()
        {
            using (var context = new SchoolContext())
            {
                var stdName = "John";
                var studentsWithSameName = context.Students
                                                  .Where(s => s.StudentName == stdName)
                                                  .ToList();

                Console.WriteLine("Studnent found: " + studentsWithSameName.Count);

                // Eager Loading
                var gradeName = "no grade";
                var studentWithGrade = context.Students
                           .Where(s => s.StudentName == "Jini")
                           .Include(s => s.Grade)
                           .FirstOrDefault();
                if (studentWithGrade != null)
                    gradeName = studentWithGrade.Grade != null ? studentWithGrade.Grade.GradeName : "no grade";

                Console.WriteLine(studentWithGrade.StudentName + " : " + gradeName);

            }
        }

        private static void DeleteData()
        {
            using (var context = new SchoolContext())
            {
                var std = context.Students.First<Student>();
                context.Students.Remove(std);

                // or
                // context.Remove<Student>(std);

                context.SaveChanges();
            }
        }

        private static void UpdateData()
        {
            using (var context = new SchoolContext())
            {
                var std = context.Students.First<Student>();


                


                std.StudentName = "Steve";
                context.SaveChanges();
            }
        }

        private static void AddData()
        {
            using (var context = new SchoolContext())
            {
                var std = new Student()
                {
                    StudentName = "Sunmi",
                    DateOfBirth = DateTime.Parse("1999-12-12")
                };
                context.Students.Add(std);

                // or
                // context.Add<Student>(std);

                context.SaveChanges();
            }
        }
    }
}
