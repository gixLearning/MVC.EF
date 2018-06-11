using System.ComponentModel.DataAnnotations;
namespace MVC.EF.Models {

    public class Assignment {
        public int AssignmentID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        [Display(Name = "Assignment Title")]        
        public string AssignmentName { get; set; }
        public virtual Course Course { get; set; }
    }
}