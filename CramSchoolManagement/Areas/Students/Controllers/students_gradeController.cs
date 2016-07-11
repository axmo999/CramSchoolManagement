﻿using System;
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
        public ActionResult Index(long? students_id)
        {
            var students_grade_list = db.students_grade.Where(students_grade => students_grade.students_id == students_id).Include(s => s.students_m);
            var students_exam = db.students_grade.Include(s => s.exams_m);
            var students_class = db.students_grade.Include(s => s.classes_m);

            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);

            return View(students_grade_list.ToList());
        }

        // GET: Students/students_grade/Details/5
        public ActionResult Details(long? students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_grade students_grade = db.students_grade.Find(id);
            if (students_grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_grade);
        }

        // GET: Students/students_grade/Create
        public ActionResult Create(int? students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name");
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name");
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View();
        }

        // POST: Students/students_grade/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_grade_id,students_id,exam_date,exam_id,class_id,exam_scores,create_user,create_date,update_user,update_date")] students_grade students_grade)
        {
            if (ModelState.IsValid)
            {
                students_grade.create_user = User.Identity.Name.ToString();
                students_grade.create_date = DateTime.Now.ToString();
                db.students_grade.Add(students_grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name", students_grade.exam_id);
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_grade.class_id);
            return View(students_grade);
        }

        // GET: Students/students_grade/Edit/5
        public ActionResult Edit(long? students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_grade students_grade = db.students_grade.Find(id);
            if (students_grade == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name", students_grade.exam_id);
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_grade.class_id);
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_grade);
        }

        // POST: Students/students_grade/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_grade_id,students_id,exam_date,exam_id,class_id,exam_scores,create_user,create_date,update_user,update_date")] students_grade students_grade)
        {
            if (ModelState.IsValid)
            {
                students_grade.update_user = User.Identity.Name.ToString();
                students_grade.update_date = DateTime.Now.ToString();
                db.Entry(students_grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.exam_id = new SelectList(setdb.exams_m, "exam_id", "name", students_grade.exam_id);
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_grade.class_id);
            return View(students_grade);
        }

        // GET: Students/students_grade/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_grade students_grade = db.students_grade.Find(id);
            if (students_grade == null)
            {
                return HttpNotFound();
            }
            return View(students_grade);
        }

        // POST: Students/students_grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            students_grade students_grade = db.students_grade.Find(id);
            db.students_grade.Remove(students_grade);
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