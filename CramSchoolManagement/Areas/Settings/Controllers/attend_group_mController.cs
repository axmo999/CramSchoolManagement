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
    public class attend_group_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/attend_group_m
        public ActionResult Index()
        {
            return View(db.attend_group_m.ToList());
        }

        // GET: Settings/attend_group_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attend_group_m attend_group_m = db.attend_group_m.Find(id);
            if (attend_group_m == null)
            {
                return HttpNotFound();
            }
            return View(attend_group_m);
        }

        // GET: Settings/attend_group_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/attend_group_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "attend_group_id,group_id,age_id,create_user,create_date,update_user,update_date")] attend_group_m attend_group_m)
        {
            if (ModelState.IsValid)
            {
                attend_group_m.create_user = User.Identity.Name.ToString();
                attend_group_m.create_date = DateTime.Now.ToString();
                db.attend_group_m.Add(attend_group_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attend_group_m);
        }

        // GET: Settings/attend_group_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attend_group_m attend_group_m = db.attend_group_m.Find(id);
            if (attend_group_m == null)
            {
                return HttpNotFound();
            }
            return View(attend_group_m);
        }

        // POST: Settings/attend_group_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "attend_group_id,group_id,age_id,create_user,create_date,update_user,update_date")] attend_group_m attend_group_m)
        {
            if (ModelState.IsValid)
            {
                attend_group_m.update_user = User.Identity.Name.ToString();
                attend_group_m.update_date = DateTime.Now.ToString();
                db.Entry(attend_group_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attend_group_m);
        }

        // GET: Settings/attend_group_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attend_group_m attend_group_m = db.attend_group_m.Find(id);
            if (attend_group_m == null)
            {
                return HttpNotFound();
            }
            return View(attend_group_m);
        }

        // POST: Settings/attend_group_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            attend_group_m attend_group_m = db.attend_group_m.Find(id);
            db.attend_group_m.Remove(attend_group_m);
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
