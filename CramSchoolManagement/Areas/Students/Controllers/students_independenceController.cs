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
    public class students_independenceController : Controller
    {
        private StudentsModel db = new StudentsModel();

        // GET: Students/students_independence
        public ActionResult Index(string students_id)
        {
            var students_independence = db.students_independence.Where(independence => independence.students_id == students_id).Include(s => s.students_m);

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            return View(students_independence.ToList());
        }

        // GET: Students/students_independence/Details/5
        public ActionResult Details(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_independence students_independence = db.students_independence.Find(num);
            if (students_independence == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            return View(students_independence);
        }

        // GET: Students/students_independence/Create
        public ActionResult Create(string students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            //ViewBag.SelectOptions = new SelectList(CramSchoolManagement.Commons.Utility.rate);
            return View();
        }

        // POST: Students/students_independence/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "independence_id,students_id,week,question01,question02,question03,question04,question05,question06,question07,question08,question09,question10,question11,question12,question13,question14,question15,create_user,create_date,update_user,update_date")] students_independence students_independence)
        {
            if (ModelState.IsValid)
            {
                students_independence.create_user = User.Identity.Name.ToString();
                students_independence.create_date = DateTime.Now.ToString();
                db.students_independence.Add(students_independence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students_independence);
        }

        // GET: Students/students_independence/Edit/5
        public ActionResult Edit(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_independence students_independence = db.students_independence.Find(num);
            if (students_independence == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_independence);
        }

        // POST: Students/students_independence/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "independence_id,students_id,week,question01,question02,question03,question04,question05,question06,question07,question08,question09,question10,question11,question12,question13,question14,question15,create_user,create_date,update_user,update_date")] students_independence students_independence)
        {
            if (ModelState.IsValid)
            {
                students_independence.update_user = User.Identity.Name.ToString();
                students_independence.update_date = DateTime.Now.ToString();
                db.Entry(students_independence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students_independence);
        }

        // GET: Students/students_independence/Delete/5
        public ActionResult Delete(long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_independence students_independence = db.students_independence.Find(num);
            if (students_independence == null)
            {
                return HttpNotFound();
            }
            return View(students_independence);
        }

        // POST: Students/students_independence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long num)
        {
            students_independence students_independence = db.students_independence.Find(num);
            db.students_independence.Remove(students_independence);
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
