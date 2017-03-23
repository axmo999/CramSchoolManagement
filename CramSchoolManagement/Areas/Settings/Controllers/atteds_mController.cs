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
    public class atteds_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/atteds_m
        public ActionResult Index()
        {
            return View(db.atteds_m.ToList());
        }

        // GET: Settings/atteds_m/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atteds_m atteds_m = db.atteds_m.Find(id);
            if (atteds_m == null)
            {
                return HttpNotFound();
            }
            return View(atteds_m);
        }

        // GET: Settings/atteds_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/atteds_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "attend_id,year_month,g0_count,g1_count,g2_count,g3_count,create_user,create_date,update_user,update_date")] atteds_m atteds_m)
        {
            if (ModelState.IsValid)
            {
                atteds_m.create_user = User.Identity.Name.ToString();
                atteds_m.create_date = DateTime.Now.ToString();
                db.atteds_m.Add(atteds_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atteds_m);
        }

        // GET: Settings/atteds_m/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atteds_m atteds_m = db.atteds_m.Find(id);
            if (atteds_m == null)
            {
                return HttpNotFound();
            }
            return View(atteds_m);
        }

        // POST: Settings/atteds_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "attend_id,year_month,g0_count,g1_count,g2_count,g3_count,create_user,create_date,update_user,update_date")] atteds_m atteds_m)
        {
            if (ModelState.IsValid)
            {
                atteds_m.update_user = User.Identity.Name.ToString();
                atteds_m.update_date = DateTime.Now.ToString();
                db.Entry(atteds_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atteds_m);
        }

        // GET: Settings/atteds_m/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atteds_m atteds_m = db.atteds_m.Find(id);
            if (atteds_m == null)
            {
                return HttpNotFound();
            }
            return View(atteds_m);
        }

        // POST: Settings/atteds_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            atteds_m atteds_m = db.atteds_m.Find(id);
            db.atteds_m.Remove(atteds_m);
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
