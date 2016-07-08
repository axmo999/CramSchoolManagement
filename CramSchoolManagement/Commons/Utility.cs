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
    }
}