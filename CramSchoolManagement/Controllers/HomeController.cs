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
            var tweet_list = db.tweet;

            ViewBag.Id = new SelectList(setdb.teachers_m, "Id", "display_name", User.Identity.GetUserId());

            return View(tweet_list);
        }

    }

}