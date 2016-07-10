using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using CramSchoolManagement.Areas.Settings.Models;
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

            var displayName = string.Empty;

            if (currentUser.last_name != null)
            {
                displayName = currentUser.last_name.ToString();
            }

            if (currentUser.middle_name != null)
            {
                displayName += " " + currentUser.middle_name.ToString();
            }

            if (currentUser.first_name != null)
            {
                displayName += " " + currentUser.first_name.ToString();
            }

            return displayName;
        }

        public static string GetDisplayName(string Id)
        {
            var manager = new UserManager<teachers_m>(new TeacherUserStore());
            var currentUser = manager.FindById(Id);

            var displayName = string.Empty;

            if (currentUser.last_name != null)
            {
                displayName = currentUser.last_name.ToString();
            }

            if (currentUser.middle_name != null)
            {
                displayName += " " + currentUser.middle_name.ToString();
            }

            if (currentUser.first_name != null)
            {
                displayName += " " + currentUser.first_name.ToString();
            }

            return displayName;
        }

        internal static dynamic GetStudentName(long? students_id)
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

        public static Dictionary<string, long> likedislike_items = new Dictionary<string, long>{
                { "好き", 1 },
                { "苦手", 2 }
        };
    }
}