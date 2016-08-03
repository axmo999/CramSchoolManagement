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
    public class average_scores_mController : Controller
    {
        private MastersModel db = new MastersModel();

        private DateTime _today = CramSchoolManagement.Commons.Utility.Today();

        // GET: Settings/average_scores_m
        public ActionResult Index()
        {
            var average_scores_m = db.average_scores_m.Include(a => a.classes_m).Include(a => a.exams_m);
            return View(average_scores_m.ToList());
        }

        // GET: Settings/average_scores_m/Details/5
        public ActionResult Details(DateTime exam_date, long? exam_id)
        {
            if (exam_date == null || exam_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            average_scores_m[] average_scores_m = db.average_scores_m.Where(x => x.exam_date == exam_date && x.exam_id == exam_id).ToArray();
            if (average_scores_m == null)
            {
                return HttpNotFound();
            }
            return View(average_scores_m);
        }

        // GET: Settings/average_scores_m/Create
        public ActionResult Create(long? division_id)
        {
            ViewBag.class_id = new SelectList(db.classes_m, "class_id", "display_name");
            ViewBag.exam_id = new SelectList(db.exams_m, "exam_id", "name");
            ViewBag.selectDivision = new SelectList(db.divisions_m, "division_id", "name", division_id);
            var classes_list = db.classes_m.Where(x => x.division_id == division_id);
            ViewBag.classes_list = classes_list.ToList();
            return View();
        }

        // POST: Settings/average_scores_m/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "class_id,exam_scores")] average_scores_m[] average_scores_m, long? division_id, DateTime exam_date, long exam_id)
        {
            if (ModelState.IsValid)
            {
                foreach (var items in average_scores_m)
                {
                    items.exam_date = exam_date;
                    items.exam_id = exam_id;
                    items.create_user = User.Identity.Name.ToString();
                    items.create_date = DateTime.Now.ToString();
                    db.average_scores_m.Add(items);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var classes_list = db.classes_m.AsEnumerable().Where(x => x.division_id == division_id);
            ViewBag.classes_list = classes_list;
            ViewBag.class_id = new SelectList(db.classes_m, "class_id", "display_name", average_scores_m.Select(x => x.class_id));
            ViewBag.exam_id = new SelectList(db.exams_m, "exam_id", "name", exam_id);
            return View(average_scores_m);
        }

        // GET: Settings/average_scores_m/Edit/5
        public ActionResult Edit(DateTime exam_date, long? exam_id)
        {
            if (exam_date == null || exam_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            average_scores_m[] average_scores_m = db.average_scores_m.Where(x => x.exam_date == exam_date && x.exam_id == exam_id).ToArray();
            if (average_scores_m == null)
            {
                return HttpNotFound();
            }
            //ViewBag.class_id = new SelectList(db.classes_m, "class_id", "display_name");
            //ViewBag.exam_id = new SelectList(db.exams_m, "exam_id", "name");
            return View(average_scores_m);
        }

        // POST: Settings/average_scores_m/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "class_id,exam_scores")] average_scores_m[] average_scores_m, DateTime exam_date, long exam_id)
        {
            if (ModelState.IsValid)
            {
                foreach (var items in average_scores_m)
                {
                    items.update_user = User.Identity.Name.ToString();
                    items.update_date = DateTime.Now.ToString();
                    db.Entry(average_scores_m).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.class_id = new SelectList(db.classes_m, "class_id", "display_name");
            ViewBag.exam_id = new SelectList(db.exams_m, "exam_id", "name");
            return View(average_scores_m);
        }

        // GET: Settings/average_scores_m/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            average_scores_m average_scores_m = db.average_scores_m.Find(id);
            if (average_scores_m == null)
            {
                return HttpNotFound();
            }
            return View(average_scores_m);
        }

        // POST: Settings/average_scores_m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            average_scores_m average_scores_m = db.average_scores_m.Find(id);
            db.average_scores_m.Remove(average_scores_m);
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
