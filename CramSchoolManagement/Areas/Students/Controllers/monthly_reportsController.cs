using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Students.Models;
using Microsoft.AspNet.Identity;

namespace CramSchoolManagement.Areas.Students.Controllers
{
    public class monthly_reportsController : Controller
    {
        private StudentsModel db = new StudentsModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();

        // GET: monthly_reports
        public ActionResult Index(string students_id)
        {
            var monthly_reports = db.monthly_reports
                                    .Where(m => m.students_id == students_id).OrderByDescending(m => m.monthly_report_date)
                                    .Include(m => m.students_m).Include(m => m.teachers_m);

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            return View(monthly_reports.ToList());
        }

        // GET: monthly_reports/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monthly_reports monthly_reports = db.monthly_reports.Find(id);
            if (monthly_reports == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentName = monthly_reports.students_m.display_name;

            return View(monthly_reports);
        }

        // GET: monthly_reports/Create
        public ActionResult Create(string students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", User.Identity.GetUserId());
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View();
        }

        // POST: monthly_reports/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "monthly_report_id,monthly_report_date,Id,students_id,study_contents,life_contents,create_user,create_date,update_user,update_date")] monthly_reports monthly_reports)
        {
            if (ModelState.IsValid)
            {
                monthly_reports.create_user = User.Identity.Name.ToString();
                monthly_reports.create_date = DateTime.Now.ToString();
                db.monthly_reports.Add(monthly_reports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.students_id = new SelectList(db.students_m, "students_id", "last_name", monthly_reports.students_id);
            ViewBag.Id = new SelectList(db.teachers_m, "Id", "display_name", monthly_reports.Id);
            return View(monthly_reports);
        }

        // GET: monthly_reports/Edit/5
        public ActionResult Edit(string students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monthly_reports monthly_reports = db.monthly_reports.Find(id);
            if (monthly_reports == null)
            {
                return HttpNotFound();
            }
            //ViewBag.students_id = new SelectList(db.students_m, "students_id", "last_name", monthly_reports.students_id);
            ViewBag.Id = new SelectList(db.teachers_m, "Id", "display_name", monthly_reports.Id);
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(monthly_reports);
        }

        // POST: monthly_reports/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "monthly_report_id,monthly_report_date,Id,students_id,study_contents,life_contents,create_user,create_date,update_user,update_date")] monthly_reports monthly_reports)
        {
            if (ModelState.IsValid)
            {
                monthly_reports.update_user = User.Identity.Name.ToString();
                monthly_reports.update_date = DateTime.Now.ToString();
                db.Entry(monthly_reports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.students_id = new SelectList(db.students_m, "students_id", "last_name", monthly_reports.students_id);
            ViewBag.Id = new SelectList(db.teachers_m, "Id", "display_name", monthly_reports.Id);
            return View(monthly_reports);
        }

        // GET: monthly_reports/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monthly_reports monthly_reports = db.monthly_reports.Find(id);
            if (monthly_reports == null)
            {
                return HttpNotFound();
            }
            return View(monthly_reports);
        }

        // POST: monthly_reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            monthly_reports monthly_reports = db.monthly_reports.Find(id);
            db.monthly_reports.Remove(monthly_reports);
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
