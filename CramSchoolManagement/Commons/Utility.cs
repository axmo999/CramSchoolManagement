using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using CramSchoolManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CramSchoolManagement.Commons
{
    public class Utility
    {
        public static string ApplicationName = "生徒管理システム";

        public static string GetDisplayName()
        {
            var manager = new UserManager<teachers_m>(new TeacherUserStore());
            var currentUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());
            var displayName = currentUser.last_name + currentUser.middle_name + currentUser.first_name;
            return displayName;
        }

        internal static dynamic GetStudentName(int? students_id)
        {
            CramSchoolManagement.Models.Students_mModel studentdb = new CramSchoolManagement.Models.Students_mModel();
            var student_person = studentdb.students_m.Single(students_m => students_m.students_id == students_id);
            string studentName = string.Empty;
            if (student_person.last_name != null)
            {
                studentName = student_person.last_name.ToString();
            }

            if (student_person.middle_name != null)
            {
                studentName += " " + student_person.middle_name.ToString();
            }

            if (student_person.first_name != null)
            {
                studentName += " " + student_person.first_name.ToString();
            }

            return studentName;
        }

    }
}