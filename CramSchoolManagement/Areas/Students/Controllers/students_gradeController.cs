using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Areas.Students.Models;
using CramSchoolManagement.Models;

namespace CramSchoolManagement.Areas.Students.Controllers
{
    public class students_gradeController : Controller
    {
        private StudentsModel db = new StudentsModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();

        // GET: Students/students_grade
        public ActionResult Index(string students_id, long division_id)
        {
            var students_grade_list = db.students_grade
                                        .Where(s => s.students_id == students_id)
                                        .Include(s => s.students_m)
                                        .Include(s => s.exams_m)
                                        .Include(s => s.classes_m).ToList();

            var average_m = setdb.average_scores_m.ToArray();

            //var studen_grade_join = students_grade_list.GroupJoin(
            //                                average_m,
            //                                (a) => new { a.exam_date.Date, a.exam_id, a.class_id, a.students_m.school_id },
            //                                (b) => new { b.exam_date.Date, b.exam_id, b.class_id, b.school_id },
            //                                (a, b) => new
            //                                {
            //                                    a,
            //                                    average_score = b.DefaultIfEmpty()
            //                                }).ToList();

            var students_exam = db.students_grade.Include(s => s.exams_m);

            var students_class = db.students_grade.Include(s => s.classes_m);

            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();

            ViewBag.average_scores = average_m;

            ViewBag.division_id = division_id;

            return View(students_grade_list);
        }

        // GET: Students/students_grade/Details/5
        public ActionResult Details(string students_id, long? num)
        {
            if (num == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_grade students_grade = db.students_grade.Find(num);
            if (students_grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_grade);
        }

        // GET: Students/students_grade/Create
        public ActionResult Create(string students_id, long? division_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name");
            //ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "display_name");
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            var classes_list = db.classes_m.Where(x => x.division_id == division_id || x.division_id == 1);
            ViewBag.classes_list = classes_list.ToList();
            ViewBag.division_id = division_id;
            return View();
        }

        // POST: Students/students_grade/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_grade_id,students_id,class_id,exam_scores,exam_precedence,create_user,create_date,update_user,update_date")] students_grade[] students_grade, DateTime exam_date, long exam_id, long? division_id)
        {
            if (ModelState.IsValid)
            {
                foreach (var items in students_grade)
                {
                    items.exam_date = exam_date;
                    items.exam_id = exam_id;
                    items.create_user = User.Identity.Name.ToString();
                    items.create_date = DateTime.Now.ToString();
                    db.students_grade.Add(items);
                }
                db.SaveChanges();
                return RedirectToAction("Index", new { division_id = division_id });
            }
            ViewBag.division_id = division_id;
            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name", exam_id);
            //ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "display_name", students_grade.class_id);
            return View(students_grade);
        }

        // GET: Students/students_grade/Edit/5
        public ActionResult Edit(string students_id, long? exam_id, DateTime exam_date, long? division_id)
        {
            if (exam_id == null || exam_date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_grade[] students_grade = db.students_grade.Where(x => x.students_id == students_id && x.exam_id == exam_id && x.exam_date == exam_date).ToArray();
            if (students_grade == null)
            {
                return HttpNotFound();
            }

            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name", exam_id);
            ViewBag.division_id = division_id;
            //ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "display_name", students_grade.class_id);
            ViewBag.StudentName = db.students_m.Single(m => m.students_id == students_id).display_name.ToString();
            return View(students_grade);
        }

        // POST: Students/students_grade/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_grade_id,students_id,class_id,exam_scores,exam_precedence,create_user,create_date")] students_grade[] students_grade, long exam_id, DateTime exam_date, long? division_id)
        {
            if (ModelState.IsValid)
            {
                foreach (var items in students_grade)
                {
                    items.exam_date = exam_date;
                    items.exam_id = exam_id;
                    items.update_user = User.Identity.Name.ToString();
                    items.update_date = DateTime.Now.ToString();
                    db.Entry(items).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index", new { division_id = division_id });
            }
            
            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name", exam_id);
            ViewBag.division_id = division_id;
            //ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "display_name", students_grade.class_id);
            return View(students_grade);
        }

        // GET: Students/students_grade/Delete/5
        public ActionResult Delete(string students_id, long? exam_id, DateTime exam_date, long? division_id)
        {
            if (exam_id == null || exam_date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_grade[] students_grade = db.students_grade.Where(x => x.students_id == students_id && x.exam_id == exam_id && x.exam_date == exam_date).ToArray();
            if (students_grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.division_id = division_id;
            return View(students_grade);
        }

        // POST: Students/students_grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string students_id, long? exam_id, DateTime exam_date, long? division_id)
        {
            students_grade[] students_grade = db.students_grade.Where(x => x.students_id == students_id && x.exam_id == exam_id && x.exam_date == exam_date).ToArray();
            foreach (var items in students_grade)
            {
                db.students_grade.Remove(items);
            }
            db.SaveChanges();
            ViewBag.division_id = division_id;
            return RedirectToAction("Index", new { division_id = division_id });
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
