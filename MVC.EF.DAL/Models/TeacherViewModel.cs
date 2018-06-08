using System.Collections.Generic;

namespace MVC.EF.Models {

    public class TeacherCourseViewModel {
        public IList<Teacher> Teachers { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<Student> EnrolledStudents { get; set; }
    }
}