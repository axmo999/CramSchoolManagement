using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Students.Models;

namespace CramSchoolManagement.Areas.Students.Controllers
{
    public class students_like_dislikeController : Controller
    {
        private StudentsModel db = new StudentsModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
        private CramSchoolManagement.Models.students_m studentdb = new CramSchoolManagement.Models.students_m();

        // GET: Students/students_like_dislike
        public ActionResult Index(int? students_id)
        {
            var students_like_dislike = db.students_like_dislike.Where(m => m.students_id == students_id).Include(s => s.students_m);
            var students_class = db.students_guide.Include(s => s.classes_m);

            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_like_dislike.ToList());
        }

        // GET: Students/students_like_dislike/Details/5
        public ActionResult Details(long? students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_like_dislike students_like_dislike = db.students_like_dislike.Find(id);
            if (students_like_dislike == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_like_dislike);
        }

        // GET: Students/students_like_dislike/Create
        public ActionResult Create(int? students_id)
        {
            ViewBag.students_id = ViewBag.students_id = students_id;
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name");
            ViewBag.like_dislike = new SelectList(CramSchoolManagement.Commons.Utility.likedislike_items, "value", "key");
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View();
        }

        // POST: Students/students_like_dislike/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_like_dislike_id,students_id,class_id,like_dislike,create_user,create_date,update_user,update_date")] students_like_dislike students_like_dislike)
        {
            if (ModelState.IsValid)
            {
                students_like_dislike.create_user = User.Identity.Name.ToString();
                students_like_dislike.create_date = DateTime.Now.ToString();
                db.students_like_dislike.Add(students_like_dislike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_like_dislike.class_id);
            ViewBag.like_dislike = new SelectList(CramSchoolManagement.Commons.Utility.likedislike_items, "value", "key", students_like_dislike.like_dislike);
            return View(students_like_dislike);
        }

        // GET: Students/students_like_dislike/Edit/5
        public ActionResult Edit(int? students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_like_dislike students_like_dislike = db.students_like_dislike.Find(id);
            if (students_like_dislike == null)
            {
                return HttpNotFound();
            }
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_like_dislike.class_id);
            ViewBag.like_dislike = new SelectList(CramSchoolManagement.Commons.Utility.likedislike_items, "value", "key", students_like_dislike.like_dislike);
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_like_dislike);
        }

        // POST: Students/students_like_dislike/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_like_dislike_id,students_id,class_id,like_dislike,create_user,create_date,update_user,update_date")] students_like_dislike students_like_dislike)
        {
            if (ModelState.IsValid)
            {
                students_like_dislike.update_user = User.Identity.Name.ToString();
                students_like_dislike.update_date = DateTime.Now.ToString();
                db.Entry(students_like_dislike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_like_dislike.class_id);
            ViewBag.like_dislike = new SelectList(CramSchoolManagement.Commons.Utility.likedislike_items, "value", "key", students_like_dislike.like_dislike);
            return View(students_like_dislike);
        }

        // GET: Students/students_like_dislike/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_like_dislike students_like_dislike = db.students_like_dislike.Find(id);
            if (students_like_dislike == null)
            {
                return HttpNotFound();
            }
            return View(students_like_dislike);
        }

        // POST: Students/students_like_dislike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            students_like_dislike students_like_dislike = db.students_like_dislike.Find(id);
            db.students_like_dislike.Remove(students_like_dislike);
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
