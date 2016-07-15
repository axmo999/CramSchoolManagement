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
    public class divisions_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/divisions_m
        public ActionResult Index()
        {
            return View(db.divisions_m.ToList());
        }

        // GET: Settings/divisions_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            divisions_m divisions_m = db.divisions_m.Find(id);
            if (divisions_m == null)
            {
                return HttpNotFound();
            }
            return View(divisions_m);
        }

        // GET: Settings/divisions_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/divisions_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "division_id,name,create_user,create_date,update_user,update_date")] divisions_m divisions_m)
        {
            if (ModelState.IsValid)
            {
                divisions_m.create_user = User.Identity.Name.ToString();
                divisions_m.create_date = DateTime.Now.ToString();
                db.divisions_m.Add(divisions_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(divisions_m);
        }

        // GET: Settings/divisions_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            divisions_m divisions_m = db.divisions_m.Find(id);
            if (divisions_m == null)
            {
                return HttpNotFound();
            }
            return View(divisions_m);
        }

        // POST: Settings/divisions_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "division_id,name,create_user,create_date,update_user,update_date")] divisions_m divisions_m)
        {
            if (ModelState.IsValid)
            {
                divisions_m.update_user = User.Identity.Name.ToString();
                divisions_m.update_date = DateTime.Now.ToString();
                db.Entry(divisions_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(divisions_m);
        }

        // GET: Settings/divisions_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            divisions_m divisions_m = db.divisions_m.Find(id);
            if (divisions_m == null)
            {
                return HttpNotFound();
            }
            return View(divisions_m);
        }

        // POST: Settings/divisions_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            divisions_m divisions_m = db.divisions_m.Find(id);
            db.divisions_m.Remove(divisions_m);
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
