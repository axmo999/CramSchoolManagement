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
    public class teachers_mController : Controller
    {
        private MastersModel db = new MastersModel();

        // GET: Settings/teachers_m
        public ActionResult Index()
        {
            var teachers_m = db.teachers_m.Include(s => s.gender_m);
            return View(db.teachers_m.ToList());
        }

        // GET: Settings/teachers_m/Details/5
        public ActionResult Details(string id)
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

        // GET: Settings/teachers_m/Create
        public ActionResult Create()
        {
            ViewBag.gender_id = new SelectList(db.gender_m, "gender_id", "gender_name");
            ViewBag.administrator_flag = new SelectList(Commons.Utility.admin_flg, "value", "key");
            return View();
        }

        // POST: Settings/teachers_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,teachers_password,last_name,first_name,middle_name,gender_id,note,administrator_flag,create_user,create_date,update_user,update_date")] teachers_m teachers_m)
        {
            if (ModelState.IsValid)
            {
                teachers_m.create_user = User.Identity.Name.ToString();
                teachers_m.create_date = DateTime.Now.ToString();
                db.teachers_m.Add(teachers_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gender_id = new SelectList(db.gender_m, "gender_id", "gender_name", teachers_m.gender_id);
            return View(teachers_m);
        }

        // GET: Settings/teachers_m/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.gender_id = new SelectList(db.gender_m, "gender_id", "gender_name", teachers_m.gender_id);
            ViewBag.administrator_flag = new SelectList(Commons.Utility.admin_flg, "value", "key", teachers_m.administrator_flag);
            return View(teachers_m);
        }

        // POST: Settings/teachers_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,teachers_password,last_name,first_name,middle_name,gender_id,note,administrator_flag,create_user,create_date,update_user,update_date")] teachers_m teachers_m)
        {
            if (ModelState.IsValid)
            {
                teachers_m.update_user = User.Identity.Name.ToString();
                teachers_m.update_date = DateTime.Now.ToString();
                db.Entry(teachers_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gender_id = new SelectList(db.gender_m, "gender_id", "gender_name", teachers_m.gender_id);
            ViewBag.administrator_flag = new SelectList(Commons.Utility.admin_flg, "value", "key", teachers_m.administrator_flag);
            return View(teachers_m);
        }

        // GET: Settings/teachers_m/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Settings/teachers_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
