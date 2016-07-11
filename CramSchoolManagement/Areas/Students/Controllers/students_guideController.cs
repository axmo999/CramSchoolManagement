﻿using System;
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
    public class students_guideController : Controller
    {
        private StudentsModel db = new StudentsModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
        private CramSchoolManagement.Models.students_m studentdb = new CramSchoolManagement.Models.students_m();

        // GET: Students/students_guide
        public ActionResult Index(int? students_id)
        {
            var students_guide = db.students_guide.Where(m => m.students_id == students_id).Include(s => s.students_m);
            var students_teacher = db.students_guide.Include(s => s.teachers_m);
            var students_class = db.students_guide.Include(s => s.classes_m);

            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_guide.ToList());
        }

        // GET: Students/students_guide/Details/5
        public ActionResult Details(long? students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_guide students_guide = db.students_guide.Find(id);
            if (students_guide == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_guide);
        }

        // GET: Students/students_guide/Create
        public ActionResult Create(int? students_id)
        {
            ViewBag.students_id = students_id;
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "UserName", User.Identity.GetUserId());
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name");
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View();
        }

        // POST: Students/students_guide/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_guide_id,students_id,guide_date,Id,class_id,guide_contents,create_user,create_date,update_user,update_date")] students_guide students_guide)
        {
            if (ModelState.IsValid)
            {
                students_guide.create_user = User.Identity.Name.ToString();
                students_guide.create_date = DateTime.Now.ToString();
                db.students_guide.Add(students_guide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "UserName", students_guide.Id);
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_guide.class_id);
            return View(students_guide);
        }

        // GET: Students/students_guide/Edit/5
        public ActionResult Edit(long? students_id, long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_guide students_guide = db.students_guide.Find(id);
            if (students_guide == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "UserName", students_guide.Id);
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_guide.class_id);
            ViewBag.StudentName = CramSchoolManagement.Commons.Utility.GetStudentName(students_id);
            return View(students_guide);
        }

        // POST: Students/students_guide/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_guide_id,students_id,guide_date,Id,class_id,guide_contents,create_user,create_date,update_user,update_date")] students_guide students_guide)
        {
            if (ModelState.IsValid)
            {
                students_guide.update_user = User.Identity.Name.ToString();
                students_guide.update_date = DateTime.Now.ToString();
                db.Entry(students_guide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "UserName", students_guide.Id);
            ViewBag.class_id = new SelectList(setdb.classes_m, "class_id", "name", students_guide.class_id);
            return View(students_guide);
        }

        // GET: Students/students_guide/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_guide students_guide = db.students_guide.Find(id);
            if (students_guide == null)
            {
                return HttpNotFound();
            }
            return View(students_guide);
        }

        // POST: Students/students_guide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            students_guide students_guide = db.students_guide.Find(id);
            db.students_guide.Remove(students_guide);
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