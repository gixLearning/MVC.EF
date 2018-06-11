using System.ComponentModel.DataAnnotations;

namespace MVC.EF.Models {

    public class CourseStudentViewModel {

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int CourseID { get; set; }
    }
}