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
    public class schools_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/schools_m
        public ActionResult Index()
        {
            var schools_m = db.schools_m.Include(s => s.divisions_m);
            return View(schools_m.ToList());
        }

        // GET: Settings/schools_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schools_m schools_m = db.schools_m.Find(id);
            if (schools_m == null)
            {
                return HttpNotFound();
            }
            return View(schools_m);
        }

        // GET: Settings/schools_m/Create
        public ActionResult Create()
        {
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name");
            return View();
        }

        // POST: Settings/schools_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "school_id,name,division_id,postal_code,address,phone_number,create_user,create_date,update_user,update_date")] schools_m schools_m)
        {
            if (ModelState.IsValid)
            {
                schools_m.create_user = User.Identity.Name.ToString();
                schools_m.create_date = DateTime.Now.ToString();
                db.schools_m.Add(schools_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", schools_m.division_id);
            return View(schools_m);
        }

        // GET: Settings/schools_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schools_m schools_m = db.schools_m.Find(id);
            if (schools_m == null)
            {
                return HttpNotFound();
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", schools_m.division_id);
            return View(schools_m);
        }

        // POST: Settings/schools_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "school_id,name,division_id,postal_code,address,phone_number,create_user,create_date,update_user,update_date")] schools_m schools_m)
        {
            if (ModelState.IsValid)
            {
                schools_m.update_user = User.Identity.Name.ToString();
                schools_m.update_date = DateTime.Now.ToString();
                db.Entry(schools_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", schools_m.division_id);
            return View(schools_m);
        }

        // GET: Settings/schools_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schools_m schools_m = db.schools_m.Find(id);
            if (schools_m == null)
            {
                return HttpNotFound();
            }
            return View(schools_m);
        }

        // POST: Settings/schools_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            schools_m schools_m = db.schools_m.Find(id);
            db.schools_m.Remove(schools_m);
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
