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
    public class offices_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/offices_m
        public ActionResult Index()
        {
            return View(db.offices_m.ToList());
        }

        // GET: Settings/offices_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            offices_m offices_m = db.offices_m.Find(id);
            if (offices_m == null)
            {
                return HttpNotFound();
            }
            return View(offices_m);
        }

        // GET: Settings/offices_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/offices_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "office_id,name,postal_code,address,phone_number,create_user,create_date,update_user,update_date")] offices_m offices_m)
        {
            if (ModelState.IsValid)
            {
                offices_m.create_user = User.Identity.Name.ToString();
                offices_m.create_date = DateTime.Now.ToString();
                db.offices_m.Add(offices_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offices_m);
        }

        // GET: Settings/offices_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            offices_m offices_m = db.offices_m.Find(id);
            if (offices_m == null)
            {
                return HttpNotFound();
            }
            return View(offices_m);
        }

        // POST: Settings/offices_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "office_id,name,postal_code,address,phone_number,create_user,create_date,update_user,update_date")] offices_m offices_m)
        {
            if (ModelState.IsValid)
            {
                offices_m.update_user = User.Identity.Name.ToString();
                offices_m.update_date = DateTime.Now.ToString();
                db.Entry(offices_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offices_m);
        }

        // GET: Settings/offices_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            offices_m offices_m = db.offices_m.Find(id);
            if (offices_m == null)
            {
                return HttpNotFound();
            }
            return View(offices_m);
        }

        // POST: Settings/offices_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            offices_m offices_m = db.offices_m.Find(id);
            db.offices_m.Remove(offices_m);
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
