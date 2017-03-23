using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Students.Models;
using Microsoft.AspNet.Identity;


namespace CramSchoolManagement.Areas.Students.Controllers
{
    public class students_interviewController : Controller
    {
        private StudentsModel db = new StudentsModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
        private CramSchoolManagement.Models.students_m studentdb = new CramSchoolManagement.Models.students_m();

        // GET: Students/students_interview
        public ActionResult Index(string students_id, string teacher_id)
        {
            var students_interview = db.students_interview.Where(m => m.students_id == students_id).OrderByDescending(m => m.interview_date).Include(s => s.students_m);
            var students_teacher = db.students_interview.Include(s => s.teachers_m);

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            ViewBag.teacher_id = new SelectList(setdb.teachers_m, "Id", "display_name");
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "display_name");

            if (teacher_id != null && teacher_id != "")
            {
                students_interview = students_interview.Where(s => s.Id.Equals(teacher_id));
            }


            return View(students_interview.ToList());
        }

        // GET: Students/students_interview/Details/5
        public ActionResult Details(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_interview students_interview = db.students_interview.Find(num);
            if (students_interview == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_interview);
        }

        // GET: Students/students_interview/Create
        public ActionResult Create(string students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", User.Identity.GetUserId());
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "display_name");
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View();
        }

        // POST: Students/students_interview/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_interview_id,students_id,interview_date,Id,interview_contents,create_user,create_date,update_user,update_date")] students_interview students_interview)
        {
            if (ModelState.IsValid)
            {
                students_interview.create_user = User.Identity.Name.ToString();
                students_interview.create_date = DateTime.Now.ToString();
                db.students_interview.Add(students_interview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", students_interview.Id);
            return View(students_interview);
        }

        // GET: Students/students_interview/Edit/5
        public ActionResult Edit(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_interview students_interview = db.students_interview.Find(num);
            if (students_interview == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", (object)students_interview.Id);
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_interview);
        }

        // POST: Students/students_interview/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_interview_id,students_id,interview_date,Id,interview_contents,create_user,create_date,update_user,update_date")] students_interview students_interview)
        {
            if (ModelState.IsValid)
            {
                students_interview.update_user = User.Identity.Name.ToString();
                students_interview.update_date = DateTime.Now.ToString();
                db.Entry(students_interview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", students_interview.Id);
            return View(students_interview);
        }

        // GET: Students/students_interview/Delete/5
        public ActionResult Delete(long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_interview students_interview = db.students_interview.Find(num);
            if (students_interview == null)
            {
                return HttpNotFound();
            }
            return View(students_interview);
        }

        // POST: Students/students_interview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            students_interview students_interview = db.students_interview.Find(id);
            db.students_interview.Remove(students_interview);
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
