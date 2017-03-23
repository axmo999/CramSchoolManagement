using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Students.Models;

namespace CramSchoolManagement.Areas.Students.Controllers
{
    public class students_attendanceController : Controller
    {
        private StudentsModel db = new StudentsModel();

        // GET: Students/students_attendance
        public ActionResult Index(string students_id)
        {
            DateTime FDM = CramSchoolManagement.Commons.Utility.getFDM();
            DateTime LDM = CramSchoolManagement.Commons.Utility.getLDM();

            var students_attendance_list = db.students_attendance.Where(
                    students_attendance => students_attendance.students_id == students_id
                    ).Include(s => s.students_m);

            ViewBag.attend_rate = CramSchoolManagement.Commons.Utility.CheckAttendRate(students_id, DateTime.Today.Year, DateTime.Today.Month);

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            ViewBag.this_year = FDM.Year;
            ViewBag.this_month = FDM.Month;

            var students_attendance_list_thismonth = students_attendance_list.Where(
                    x => x.attendance_day >= FDM &&
                         x.attendance_day <= LDM
                ).OrderByDescending(x => x.attendance_day);

            var students_attendance_list_month = students_attendance_list.GroupBy(
                        s => s.attendance_day.Year + "/" + s.attendance_day.Month
                    ).Select(
                        s => s.Key
                    ).ToList();

            ViewBag.attend_archive = students_attendance_list_month;

            return View(students_attendance_list_thismonth.ToList());
        }

        public ActionResult Archive(string students_id, int year, int month)
        {
            DateTime FDM = CramSchoolManagement.Commons.Utility.getFDM(year, month);
            DateTime LDM = CramSchoolManagement.Commons.Utility.getLDM(year, month);

            var students_attendance_list = db.students_attendance.Where(
                    students_attendance => students_attendance.students_id == students_id
                    ).Include(s => s.students_m);

            ViewBag.attend_rate = CramSchoolManagement.Commons.Utility.CheckAttendRate(students_id, year, month);

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            ViewBag.this_year = FDM.Year;
            ViewBag.this_month = FDM.Month;

            var students_attendance_list_thismonth = students_attendance_list.Where(
                        x => x.attendance_day >= FDM &&
                             x.attendance_day <= LDM
                    ).OrderByDescending(x => x.attendance_day);

            var students_attendance_list_month = students_attendance_list.GroupBy(
                        s => s.attendance_day.Year + "/" + s.attendance_day.Month
                    ).Select(
                        s => s.Key
                    ).ToList();

            ViewBag.attend_archive = students_attendance_list_month;

            return View(students_attendance_list_thismonth.ToList());
        }

        // GET: Students/students_attendance/Details/5
        public ActionResult Details(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_attendance students_attendance = db.students_attendance.Find(num);
            if (students_attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_attendance);
        }

        // GET: Students/students_attendance/Create
        public ActionResult Create(string students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View();
        }

        // POST: Students/students_attendance/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_attendance_id,students_id,attendance_day,start_time,end_time,create_user,create_date,update_user,update_date")] students_attendance students_attendance)
        {
            if (ModelState.IsValid)
            {
                students_attendance.create_user = User.Identity.Name.ToString();
                students_attendance.create_date = DateTime.Now.ToString();
                db.students_attendance.Add(students_attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students_attendance);
        }

        // GET: Students/students_attendance/Edit/5
        public ActionResult Edit(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_attendance students_attendance = db.students_attendance.Find(num);
            if (students_attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_attendance);
        }

        // POST: Students/students_attendance/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_attendance_id,students_id,attendance_day,start_time,end_time,create_user,create_date,update_user,update_date")] students_attendance students_attendance)
        {
            if (ModelState.IsValid)
            {
                students_attendance.update_user = User.Identity.Name.ToString();
                students_attendance.update_date = DateTime.Now.ToString();
                db.Entry(students_attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students_attendance);
        }

        // GET: Students/students_attendance/Delete/5
        public ActionResult Delete(long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_attendance students_attendance = db.students_attendance.Find(num);
            if (students_attendance == null)
            {
                return HttpNotFound();
            }
            return View(students_attendance);
        }

        // POST: Students/students_attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long num)
        {
            students_attendance students_attendance = db.students_attendance.Find(num);
            db.students_attendance.Remove(students_attendance);
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
