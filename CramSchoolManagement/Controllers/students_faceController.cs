using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CramSchoolManagement.Models;

namespace CramSchoolManagement.Controllers
{
    public class students_faceController : Controller
    {
        private Students_mModel db = new Students_mModel();
        // GET: students_face
        public ActionResult Index(long id)
        {
            var fileToRetrieve = db.students_face.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}