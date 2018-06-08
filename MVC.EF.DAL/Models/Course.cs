using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.EF.Models {

    public class Course {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int TeacherID { get; set; }
        public virtual IList<Student> EnrolledStudents { get; set; }
        public virtual IList<Assignment> Assignments { get; set; }
    }
}