using System;
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
        private CramSchoolManagement.Areas.Students.Models.StudentsModel studentdb = new Areas.Students.Models.StudentsModel();

        // GET: /students_m
        public ActionResult Index(long? school_id, long? school_grade, long? office_id)
        {
            var student_list = db.students_m.Include(s => s.schools_m).Include(s => s.offices_m).AsEnumerable();

            if (school_id != null)
            {
                student_list = student_list.Where(s => s.school_id == school_id);
            }
            if (school_grade != null)
            {
                student_list = student_list.Where(s => s.gradeint == school_grade);
            }
            if (office_id != null)
            {
                student_list = student_list.Where(s => s.office_id == office_id);
            }

            //var students_m_gender = db.students_m.Include(s => s.gender_m);
            //var students_m_school = db.students_m.Include(s => s.schools_m);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name");
            ViewBag.school_grade = new SelectList(setdb.age_m, "age", "display_name");
            ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name");
            return View(student_list);
        }

        // GET: /students_m/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_m students_m = db.students_m.Include(s => s.students_face).SingleOrDefault(s => s.students_id == id);
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
            ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name");
            return View();
        }

        // POST: /students_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "students_id,last_name,first_name,middle_name,school_id,gender_id,birthday,club,office_id,postal_code,address,phone_number,hope_school,enter_school,note,create_user,create_date,update_user,update_date")] students_m students_m, HttpPostedFileBase face_img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (face_img != null && face_img.ContentLength > 0 && face_img.ContentType.StartsWith("image/"))
                    {
                        var face = new students_face
                        {
                            FileName = System.IO.Path.GetFileName(face_img.FileName),
                            FileType = "Image",
                            ContentType = face_img.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(face_img.InputStream))
                        {
                            face.Content = reader.ReadBytes(face_img.ContentLength);
                        }
                        students_m.students_face = new List<students_face> { face };
                    }

                    students_m.create_user = User.Identity.Name.ToString();
                    students_m.create_date = DateTime.Now.ToString();
                    db.students_m.Add(students_m);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                return RedirectToAction("Index");
            }

            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name", students_m.gender_id);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name", students_m.school_id);
            ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name", students_m.office_id);
            return View(students_m);
        }

        // GET: /students_m/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_m students_m = db.students_m.Include(s => s.students_face).SingleOrDefault(s => s.students_id == id);
            if (students_m == null)
            {
                return HttpNotFound();
            }
            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name", students_m.gender_id);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name", students_m.school_id);
            ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name", students_m.office_id);
            ViewBag.likedislikeclass_id = new SelectList(setdb.classes_m, "class_id", "name");
            return View(students_m);
        }

        // POST: /students_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "students_id,last_name,first_name,middle_name,school_id,gender_id,birthday,club,office_id,postal_code,address,phone_number,hope_school,enter_school,note,create_user,create_date,update_user,update_date")] students_m students_m, string id, HttpPostedFileBase face_img)
        {
            if (ModelState.IsValid)
            {
                var studentToUpdate = db.students_m.Find(id);
                if (TryUpdateModel(studentToUpdate, "", new string[] { "students_id", "last_name", "first_name", "middle_name", "school_id", "gender_id", "birthday", "club", "office_id", "postal_code", "address", "phone_number", "hope_school", "enter_school", "note", "create_user", "create_date", "update_user", "update_date" }))
                {
                    try
                    {
                        if (face_img != null && face_img.ContentLength > 0 && face_img.ContentType.StartsWith("image/"))
                        {
                            if (studentToUpdate.students_face.Any(f => f.FileType == "Image"))
                            {
                                db.students_face.Remove(studentToUpdate.students_face.First(f => f.FileType == "Image"));
                            }

                            var face = new students_face
                            {
                                FileName = System.IO.Path.GetFileName(face_img.FileName),
                                FileType = "Image",
                                ContentType = face_img.ContentType
                            };
                            using (var reader = new System.IO.BinaryReader(face_img.InputStream))
                            {
                                face.Content = reader.ReadBytes(face_img.ContentLength);
                            }
                            studentToUpdate.students_face = new List<students_face> { face };
                        }

                        studentToUpdate.update_user = User.Identity.Name.ToString();
                        studentToUpdate.update_date = DateTime.Now.ToString();
                        db.Entry(studentToUpdate).State = EntityState.Modified;
                        //db.Entry(students_m).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }

                    return RedirectToAction("Index");
                }
            }
            ViewBag.gender_id = new SelectList(setdb.gender_m, "gender_id", "gender_name", students_m.gender_id);
            ViewBag.school_id = new SelectList(setdb.schools_m, "school_id", "name", students_m.school_id);
            ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name", students_m.office_id);
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
        public ActionResult DeleteConfirmed(string id)
        {
            //生徒情報削除
            students_m students_m = db.students_m.Find(id);
            db.students_m.Remove(students_m);
            
            //生徒関連情報削除
            db.students_face.RemoveRange(db.students_face.Where(x => x.students_id == id));
            studentdb.students_attendance.RemoveRange(studentdb.students_attendance.Where(x => x.students_id == id));
            studentdb.students_grade.RemoveRange(studentdb.students_grade.Where(x => x.students_id == id));
            studentdb.students_guide.RemoveRange(studentdb.students_guide.Where(x => x.students_id == id));
            studentdb.students_like_dislike.RemoveRange(studentdb.students_like_dislike.Where(x => x.students_id == id));

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

        public ActionResult CheckIn(string id)
        {
            Areas.Students.Models.StudentsModel studentdb = new Areas.Students.Models.StudentsModel();
            Areas.Students.Models.students_attendance attends = new Areas.Students.Models.students_attendance();

            attends.students_id = id;
            attends.attendance_day = DateTime.Today.ToString("yyyy-MM-dd");
            attends.start_time = DateTime.Now.ToString("HH:mm");

            attends.create_user = User.Identity.Name.ToString();
            attends.create_date = DateTime.Now.ToString();

            studentdb.students_attendance.Add(attends);
            studentdb.SaveChanges();

            students_m students_m = db.students_m.Find(id);

            ViewBag.Announce = students_m.display_name + "が出席しました。";

            return RedirectToAction("Index");
        }

        public ActionResult CheckOut(string id)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            Areas.Students.Models.StudentsModel studentdb = new Areas.Students.Models.StudentsModel();
            Areas.Students.Models.students_attendance attends = studentdb.students_attendance.FirstOrDefault(x => x.students_id == id && x.attendance_day == today);

            if (attends != null)
            {
                attends.end_time = DateTime.Now.ToString("HH:mm");

                attends.update_user = User.Identity.Name.ToString();
                attends.update_date = DateTime.Now.ToString();
                studentdb.Entry(attends).State = EntityState.Modified;
                studentdb.SaveChanges();

                students_m students_m = db.students_m.Find(id);

                ViewBag.Announce = students_m.display_name + "が退席しました。";

            }


            return RedirectToAction("Index");
        }
    }
}
