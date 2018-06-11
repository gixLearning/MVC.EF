using MVC.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC.EF.Models {
    public class CreateCourseViewModel {
        public IList<SelectListItem> Teachers { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public Course Course { get; set; }
         
    }
}
