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
    public class classes_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/classes_m
        public ActionResult Index()
        {
            var classes_m = db.classes_m.Include(s => s.divisions_m);
            return View(classes_m.ToList());
        }

        // GET: Settings/classes_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classes_m classes_m = db.classes_m.Find(id);
            if (classes_m == null)
            {
                return HttpNotFound();
            }
            return View(classes_m);
        }

        // GET: Settings/classes_m/Create
        public ActionResult Create()
        {
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name");
            return View();
        }

        // POST: Settings/classes_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "class_id,division_id,name,eng_name,create_user,create_date,update_user,update_date")] classes_m classes_m)
        {
            if (ModelState.IsValid)
            {
                classes_m.create_user = User.Identity.Name.ToString();
                classes_m.create_date = DateTime.Now.ToString();
                db.classes_m.Add(classes_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", classes_m.division_id);
            return View(classes_m);
        }

        // GET: Settings/classes_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classes_m classes_m = db.classes_m.Find(id);
            if (classes_m == null)
            {
                return HttpNotFound();
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", classes_m.division_id);
            return View(classes_m);
        }

        // POST: Settings/classes_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "class_id,division_id,name,eng_name,create_user,create_date,update_user,update_date")] classes_m classes_m)
        {
            if (ModelState.IsValid)
            {
                classes_m.update_user = User.Identity.Name.ToString();
                classes_m.update_date = DateTime.Now.ToString();
                db.Entry(classes_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.division_id = new SelectList(db.divisions_m, "division_id", "name", classes_m.division_id);
            return View(classes_m);
        }

        // GET: Settings/classes_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classes_m classes_m = db.classes_m.Find(id);
            if (classes_m == null)
            {
                return HttpNotFound();
            }
            return View(classes_m);
        }

        // POST: Settings/classes_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            classes_m classes_m = db.classes_m.Find(id);
            db.classes_m.Remove(classes_m);
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
