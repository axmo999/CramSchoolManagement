﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Models;

namespace CramSchoolManagement.Controllers
{
    public class students_mController : Controller
    {
        private Students_mModel db = new Students_mModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();

        // GET: /students_m
        public ActionResult Index()
        {
            var students_m_gender = db.students_m.Include(s => s.gender_m);
            var students_m_school = db.students_m.Include(s => s.schools_m);
            return View(db.students_m.ToList());
        }

        // GET: /students_m/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_m students_m = db.students_m.Find(id);
            if (students_m == null)
            {
                return HttpNotFound();
            }
            return View(students_m);
        }

        // GET: /students_m/Create
        public ActionResult Create()
        {
            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name");
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name");
            return View();
        }

        // POST: /students_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_id,last_name,first_name,middle_name,school_id,gender_id,birthday,face,postal_code,address,phone_number,hope_school,enter_school,note,create_user,create_date,update_user,update_date")] students_m students_m)
        {
            if (ModelState.IsValid)
            {
                students_m.create_user = User.Identity.Name.ToString();
                students_m.create_date = DateTime.Now.ToString();
                db.students_m.Add(students_m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name", students_m.gender_id);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name", students_m.gender_id);
            return View(students_m);
        }

        // GET: /students_m/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_m students_m = db.students_m.Find(id);
            if (students_m == null)
            {
                return HttpNotFound();
            }
            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name", students_m.gender_id);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name", students_m.gender_id);
            return View(students_m);
        }

        // POST: /students_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_id,last_name,first_name,middle_name,school_id,gender_id,birthday,face,postal_code,address,phone_number,hope_school,enter_school,note,create_user,create_date,update_user,update_date")] students_m students_m)
        {
            if (ModelState.IsValid)
            {
                students_m.update_user = User.Identity.Name.ToString();
                students_m.update_date = DateTime.Now.ToString();
                db.Entry(students_m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name", students_m.gender_id);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name", students_m.gender_id);
            return View(students_m);
        }

        // GET: /students_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_m students_m = db.students_m.Find(id);
            if (students_m == null)
            {
                return HttpNotFound();
            }
            return View(students_m);
        }

        // POST: /students_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            students_m students_m = db.students_m.Find(id);
            db.students_m.Remove(students_m);
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