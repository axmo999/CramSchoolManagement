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
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Name = GetDisplayName();
            return View();
        }

        public string GetDisplayName()
        {
            var manager = new UserManager<teachers_m>(new TeacherUserStore());
            var currentUser = manager.FindById(HttpContext.User.Identity.GetUserId());
            var displayName = string.Empty; 
            if (currentUser != null)
            {
                displayName = currentUser.last_name + currentUser.middle_name + currentUser.first_name;
            }

            return displayName;
        }
    }

}