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
    public class age_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/age_m
        public ActionResult Index()
        {
            var age_m = db.age_m.Include(a => a.divisions_m);
            return View(age_m.ToList());
        }

        // GET: Settings/age_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            age_m age_m = db.age_m.Find(id);
            if (age_m == null)
            {
                return HttpNotFound();
            }
            return View(age_m);
        }

        // GET: Settings/age_m/Create
        public ActionResult Create()
        {
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name");
            return View();
        }

        // POST: Settings/age_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "age_id,age,division_id,grade,create_user,create_date,update_user,update_date")] age_m age_m)
        {
            if (ModelState.IsValid)
            {
                age_m.create_user = User.Identity.Name.ToString();
                age_m.create_date = DateTime.Now.ToString();
                db.age_m.Add(age_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", age_m.division_id);
            return View(age_m);
        }

        // GET: Settings/age_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            age_m age_m = db.age_m.Find(id);
            if (age_m == null)
            {
                return HttpNotFound();
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", age_m.division_id);
            return View(age_m);
        }

        // POST: Settings/age_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "age_id,age,division_id,grade,create_user,create_date,update_user,update_date")] age_m age_m)
        {
            if (ModelState.IsValid)
            {
                age_m.update_user = User.Identity.Name.ToString();
                age_m.update_date = DateTime.Now.ToString();
                db.Entry(age_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", age_m.division_id);
            return View(age_m);
        }

        // GET: Settings/age_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            age_m age_m = db.age_m.Find(id);
            if (age_m == null)
            {
                return HttpNotFound();
            }
            return View(age_m);
        }

        // POST: Settings/age_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            age_m age_m = db.age_m.Find(id);
            db.age_m.Remove(age_m);
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
