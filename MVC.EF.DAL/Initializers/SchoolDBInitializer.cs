using MVC.EF.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC.EF.DAL {

    public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<SchoolDBContext> {

        protected override void Seed(SchoolDBContext context) {
            var students = new List<Student>() {
                new Student { FirstName = "Robot", LastName = "Roboto" },
                new Student { FirstName = "Sauron", LastName = "Edgelord" },
                new Student { FirstName = "Jon", LastName = "Snow" },
                new Student { FirstName = "Wicked", LastName = "Ewok" }
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>() {
                new Teacher { Firstname = "Dova", Lastname = "Khin" },
                new Teacher { Firstname = "Moria", Lastname = "Hesengaard" }
            };
            teachers.ForEach(t => context.Teachers.Add(t));
            context.SaveChanges();

            var courses = new List<Course>() {
                new Course { CourseID = 1040, CourseName = ".NET Intermediate",
                    TeacherID = teachers[0].TeacherID,
                    EnrolledStudents = new List<Student>() { students[0], students[1] }
                },
                new Course { CourseID = 1031, CourseName = "EF and Databases",
                    TeacherID = teachers[1].TeacherID,
                    EnrolledStudents = new List<Student>() { students[0], students[1], students[2] }
                },
                new Course { CourseID = 1010, CourseName = "Good Code Practises",
                    TeacherID = teachers[1].TeacherID,
                    EnrolledStudents = new List<Student>() { students[0], students[1], students[2], students[3] }
                }
            };
            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var assignments = new List<Assignment>() {
                new Assignment { AssignmentName="Bad code", CourseID = 1040 }
            };
            assignments.ForEach(a => context.Assignments.Add(a));
            context.SaveChanges();
        }
    }
}