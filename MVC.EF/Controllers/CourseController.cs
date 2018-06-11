using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.EF.DAL;
using MVC.EF.Models;

namespace MVC.EF.Controllers
{
    public class CourseController : Controller
    {
        private SchoolDBContext db = new SchoolDBContext();

        // GET: Course
        public ActionResult Index()
        {
            //select FirstName from Teachers, Courses
            //where Teachers.TeacherID = Courses.TeacherID AND Courses.TeacherID = 1;

            return View(db.Courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            //course.Assignments = db.Assignments
            //    .Where(a => a.CourseID == course.CourseID)
            //    .ToList();

            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var model = new CreateCourseViewModel {
                Teachers = db.Teachers.Select(t => new SelectListItem {
                    Text = t.Firstname + " " + t.Lastname,
                    Value = t.TeacherID.ToString()
                }).ToList()
            };
            return View(model);
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse(CreateCourseViewModel model) 
        {
            Course course;
            if (ModelState.IsValid)
            {
                course = db.Courses.Find(model.Course.CourseID);
                if(course != null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "A course with that id already exists.");
                }

                course = model.Course;
                course.TeacherID = model.TeacherId;
                
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            //return View(course);
        }

        public ActionResult AddAssignment(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null) {
                return HttpNotFound();
            }

            Assignment assignment = new Assignment {
                CourseID = course.CourseID,
                Course = course
            };


            return View(assignment);
        }

        [HttpPost, ActionName("AddAssignment")]
        [ValidateAntiForgeryToken]
        public ActionResult AddAssignment([Bind(Include = "AssignmentName,CourseID")]Assignment assignment) {

            if (ModelState.IsValid) {
                db.Assignments.Add(assignment);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = assignment.CourseID });
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        public ActionResult AddStudent(int? id) {

            return View();
        }
        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,TeacherID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
