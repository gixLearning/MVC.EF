namespace MVC.EF.Models {

    public class Assignment {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public string AssignmentName { get; set; }

        public virtual Course Course { get; set; }
    }
}