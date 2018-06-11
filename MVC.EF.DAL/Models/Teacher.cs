using System.Collections.Generic;

namespace MVC.EF.Models {

    public class Teacher {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int TeacherID { get; set; }
        public virtual IList<Course> Courses { get; set; }

        public string FullName {
            get {
                return Firstname + " " + Lastname;
            }
        }
    }
}