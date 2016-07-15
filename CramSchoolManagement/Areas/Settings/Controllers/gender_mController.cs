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
    public class gender_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/gender_m
        public ActionResult Index()
        {
            return View(db.gender_m.ToList());
        }

        // GET: Settings/gender_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gender_m gender_m = db.gender_m.Find(id);
            if (gender_m == null)
            {
                return HttpNotFound();
            }
            return View(gender_m);
        }

        // GET: Settings/gender_m/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/gender_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gender_id,gender_name,create_user,create_date,update_user,update_date")] gender_m gender_m)
        {
            if (ModelState.IsValid)
            {
                gender_m.create_user = User.Identity.Name.ToString();
                gender_m.create_date = DateTime.Now.ToString();
                db.gender_m.Add(gender_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gender_m);
        }

        // GET: Settings/gender_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gender_m gender_m = db.gender_m.Find(id);
            if (gender_m == null)
            {
                return HttpNotFound();
            }
            return View(gender_m);
        }

        // POST: Settings/gender_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gender_id,gender_name,create_user,create_date,update_user,update_date")] gender_m gender_m)
        {
            if (ModelState.IsValid)
            {
                gender_m.update_user = User.Identity.Name.ToString();
                gender_m.update_date = DateTime.Now.ToString();
                db.Entry(gender_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender_m);
        }

        // GET: Settings/gender_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gender_m gender_m = db.gender_m.Find(id);
            if (gender_m == null)
            {
                return HttpNotFound();
            }
            return View(gender_m);
        }

        // POST: Settings/gender_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            gender_m gender_m = db.gender_m.Find(id);
            db.gender_m.Remove(gender_m);
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
