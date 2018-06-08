using System.Web.Mvc;
using MVC.EF.DAL;
using MVC.EF.Models;
using System.Linq;

namespace MVC.EF.Controllers {

    public class HomeController : Controller {        

        // GET: Home
        public ActionResult Index() {
            //using (var ctx = new SchoolDBContext()) {
            //    if (ctx.Students.Any()) {
            //        return Content(ctx.Students.First().FirstName);
            //    }
            //}

            return View();
        }
    }
}