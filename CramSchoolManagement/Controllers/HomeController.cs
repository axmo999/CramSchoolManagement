using CramSchoolManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CramSchoolManagement.Controllers
{
    public class HomeController : Controller
    {

        private Students_mModel db = new Students_mModel();
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
        private DateTime _today = CramSchoolManagement.Commons.Utility.Today();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.tweet_list = db.tweet.ToList();

            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", User.Identity.GetUserId());

            if (Request.Cookies["office_id"] != null)
            {
                ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name", Request.Cookies["office_id"].Value);
                ViewBag.tweet_list = db.tweet.Where(x => x.office_id == Convert.ToInt32(Request.Cookies["office_id"].Value)).ToList();
            }
            else
            {
                ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name");
                ViewBag.tweet_list = db.tweet.ToList();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,office_id,tweet_comment")] tweet tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.tweet_date = _today;
                tweet.create_user = User.Identity.Name.ToString();
                tweet.create_date = _today;
                db.tweet.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tweet_list = db.tweet.ToList();

            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", User.Identity.GetUserId());

            ViewBag.office_id = new SelectList(setdb.offices_m, "office_id", "name");

            return View();
        }

    }

}