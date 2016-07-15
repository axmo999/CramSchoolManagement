using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Settings.Models;

namespace CramSchoolManagement.Areas.Settings.Controllers
{
    public class exams_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/exams_m
        public ActionResult Index()
        {
            return View(db.exams_m.ToList());
        }

        // GET: Settings/exams_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exams_m exams_m = db.exams_m.Find(id);
            if (exams_m == null)
            {
                return HttpNotFound();
            }
            return View(exams_m);
        }

        // GET: Settings/exams_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/exams_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exam_id,name,create_user,create_date,update_user,update_date")] exams_m exams_m)
        {
            if (ModelState.IsValid)
            {
                exams_m.create_user = User.Identity.Name.ToString();
                exams_m.create_date = DateTime.Now.ToString();
                db.exams_m.Add(exams_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exams_m);
        }

        // GET: Settings/exams_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exams_m exams_m = db.exams_m.Find(id);
            if (exams_m == null)
            {
                return HttpNotFound();
            }
            return View(exams_m);
        }

        // POST: Settings/exams_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exam_id,name,create_user,create_date,update_user,update_date")] exams_m exams_m)
        {
            if (ModelState.IsValid)
            {
                exams_m.update_user = User.Identity.Name.ToString();
                exams_m.update_date = DateTime.Now.ToString();
                db.Entry(exams_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exams_m);
        }

        // GET: Settings/exams_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exams_m exams_m = db.exams_m.Find(id);
            if (exams_m == null)
            {
                return HttpNotFound();
            }
            return View(exams_m);
        }

        // POST: Settings/exams_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            exams_m exams_m = db.exams_m.Find(id);
            db.exams_m.Remove(exams_m);
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
