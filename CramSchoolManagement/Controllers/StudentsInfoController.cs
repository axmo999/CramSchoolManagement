using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Models;

namespace CramSchoolManagement.Controllers
{
    public class StudentsInfoController : Controller
    {
        private Students_mModel db = new Students_mModel();
        // GET: StudentsInfo
        public ActionResult Index(long id)
        {
            var studentifno = db.students_m.Find(id);

            return View();
        }
    }
}