using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MVC.EF.Models {

    public class Student {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IList<Course> Courses { get; set; }        

        [Display(Name = "Full Name")]
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }
    }
}