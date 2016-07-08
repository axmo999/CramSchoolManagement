using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Users.Models;

namespace CramSchoolManagement.Areas.Users.Controllers
{
    public class TeacherController : Controller
    {
        private UserModel db = new UserModel();

        // GET: Users/Teacher
        public ActionResult Index()
        {
            return View(db.teachers_m.ToList());
        }

        // GET: Users/Teacher/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teachers_m teachers_m = db.teachers_m.Find(id);
            if (teachers_m == null)
            {
                return HttpNotFound();
            }
            return View(teachers_m);
        }

        // GET: Users/Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Teacher/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teachers_id,teachers_password,last_name,first_name,middle_name,gender,note,administrator_flag,create_user,create_date,update_user,update_date")] teachers_m teachers_m)
        {
            if (ModelState.IsValid)
            {
                db.teachers_m.Add(teachers_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teachers_m);
        }

        // GET: Users/Teacher/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teachers_m teachers_m = db.teachers_m.Find(id);
            if (teachers_m == null)
            {
                return HttpNotFound();
            }
            return View(teachers_m);
        }

        // POST: Users/Teacher/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teachers_id,teachers_password,last_name,first_name,middle_name,gender,note,administrator_flag,create_user,create_date,update_user,update_date")] teachers_m teachers_m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers_m);
        }

        // GET: Users/Teacher/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teachers_m teachers_m = db.teachers_m.Find(id);
            if (teachers_m == null)
            {
                return HttpNotFound();
            }
            return View(teachers_m);
        }

        // POST: Users/Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            teachers_m teachers_m = db.teachers_m.Find(id);
            db.teachers_m.Remove(teachers_m);
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
