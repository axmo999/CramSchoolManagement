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
    public class students_independenceController : Controller
    {
        private StudentsModel db = new StudentsModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();

        // GET: Students/students_independence
        public ActionResult Index(string students_id)
        {
            var students_independence = db.students_independence.Where(independence => independence.students_id == students_id).Include(s => s.students_m);

            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name");
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            return View(students_independence.ToList());
        }

        // GET: Students/students_independence/Details/5
        public ActionResult Details(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_independence students_independence = db.students_independence.Find(num);
            if (students_independence == null)
            {
                return HttpNotFound();
            }

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            return View(students_independence);
        }

        // GET: Students/students_independence/Create
        public ActionResult Create(string students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", User.Identity.GetUserId());
            return View();
        }

        // POST: Students/students_independence/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "independence_id,students_id,Id,week,question01,question02,question03,question04,question05,question06,question07,question08,question09,question10,question11,question12,question13,question14,question15,create_user,create_date,update_user,update_date")] students_independence students_independence)
        {
            if (ModelState.IsValid)
            {
                students_independence.create_user = User.Identity.Name.ToString();
                students_independence.create_date = DateTime.Now.ToString();
                db.students_independence.Add(students_independence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", students_independence.Id);
            return View(students_independence);
        }

        // GET: Students/students_independence/Edit/5
        public ActionResult Edit(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_independence students_independence = db.students_independence.Find(num);
            if (students_independence == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", (object)students_independence.Id);
            return View(students_independence);
        }

        // POST: Students/students_independence/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "independence_id,students_id,week,Id,question01,question02,question03,question04,question05,question06,question07,question08,question09,question10,question11,question12,question13,question14,question15,create_user,create_date,update_user,update_date")] students_independence students_independence)
        {
            if (ModelState.IsValid)
            {
                students_independence.update_user = User.Identity.Name.ToString();
                students_independence.update_date = DateTime.Now.ToString();
                db.Entry(students_independence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", students_independence.Id);
            return View(students_independence);
        }

        // GET: Students/students_independence/Delete/5
        public ActionResult Delete(long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_independence students_independence = db.students_independence.Find(num);
            if (students_independence == null)
            {
                return HttpNotFound();
            }
            return View(students_independence);
        }

        // POST: Students/students_independence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long num)
        {
            students_independence students_independence = db.students_independence.Find(num);
            db.students_independence.Remove(students_independence);
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

        public ActionResult ArchiveMonth(string students_id, int year, int month)
        {
            ViewBag.students_id = students_id;
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            DateTime FDM = CramSchoolManagement.Commons.Utility.getFDM(year, month);
            DateTime LDM = CramSchoolManagement.Commons.Utility.getLDM(year, month);
            
            ViewBag.this_year = FDM.Year;
            ViewBag.this_month = FDM.Month;

            var independence_list = db.students_independence.Where(independence => independence.students_id == students_id).Include(s => s.students_m);
            
            var independence_month = independence_list.Where(
                        x => x.week >= FDM &&
                             x.week <= LDM
                    ).OrderByDescending(x => x.week);

            students_independence student_independent = new students_independence();
            student_independent.question01 = independence_month.Average(x => x.question01);
            student_independent.question02 = independence_month.Average(x => x.question02);
            student_independent.question03 = independence_month.Average(x => x.question03);
            student_independent.question04 = independence_month.Average(x => x.question04);
            student_independent.question05 = independence_month.Average(x => x.question05);
            student_independent.question06 = independence_month.Average(x => x.question06);
            student_independent.question07 = independence_month.Average(x => x.question07);
            student_independent.question08 = independence_month.Average(x => x.question08);
            student_independent.question09 = independence_month.Average(x => x.question09);
            student_independent.question10 = independence_month.Average(x => x.question10);
            student_independent.question11 = independence_month.Average(x => x.question11);
            student_independent.question12 = independence_month.Average(x => x.question12);
            student_independent.question13 = independence_month.Average(x => x.question13);
            student_independent.question14 = independence_month.Average(x => x.question14);
            student_independent.question15 = independence_month.Average(x => x.question15);

            decimal total = independence_month.Count();

            decimal rank1 = (student_independent.question01 
                            + student_independent.question02
                            + student_independent.question03
                            + student_independent.question04
                            + student_independent.question05) / 5;

            

            decimal rank2 = (student_independent.question06
                            + student_independent.question07
                            + student_independent.question08
                            + student_independent.question09) / 4;

            decimal rank3 = (student_independent.question10
                            + student_independent.question11
                            + student_independent.question12
                            + student_independent.question13) / 4;

            decimal rank4 = (student_independent.question14
                            + student_independent.question15) / 2;

            ViewBag.rank1 = rank1;
            ViewBag.rank2 = rank2;
            ViewBag.rank3 = rank3;
            ViewBag.rank4 = rank4;

            ViewBag.total_ave = (rank1 + rank2 + rank3 + rank4) / 4;

            var independent_list_final =  independence_month.ToList();
            independent_list_final.Add(student_independent);

            var independence_list_month = independence_list.GroupBy(
                       s => s.week.Year + "/" + s.week.Month
                   ).Select(
                       s => s.Key
                   ).ToList();

            ViewBag.attend_archive = independence_list_month;

            return View(independent_list_final);
        }
    }
}
