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

        //internal static dynamic GetStudentName(long? students_id)
        //{
        //    CramSchoolManagement.Models.Students_mModel studentdb = new CramSchoolManagement.Models.Students_mModel();
        //    var student_person = studentdb.students_m.Single(students_m => students_m.students_id == students_id);
        //    string studentName = string.Empty;
        //    if (student_person.last_name != null)
        //    {
        //        studentName = student_person.last_name.ToString();
        //    }

        //    if (student_person.middle_name != null)
        //    {
        //        studentName += " " + student_person.middle_name.ToString();
        //    }

        //    if (student_person.first_name != null)
        //    {
        //        studentName += " " + student_person.first_name.ToString();
        //    }

        //    return studentName;
        //}

        /// <summary>
        /// 教科管理番号から教科名を表示します。
        /// </summary>
        /// <param name="class_id">教科管理番号</param>
        /// <returns>教科名</returns>
        public static string GetClassName(long? class_id)
        {
            CramSchoolManagement.Areas.Settings.Models.MastersModel masterdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
            string className = masterdb.classes_m.Single(x => x.class_id == class_id).display_name.ToString();
            return className;
        }

        public static string GetExamName(long exam_id)
        {
            CramSchoolManagement.Areas.Settings.Models.MastersModel masterdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
            string examname = masterdb.exams_m.Single(x => x.exam_id == exam_id).name.ToString(); ;
            return examname;
        }

        /// <summary>
        /// 年齢を計算します。
        /// </summary>
        /// <param name="stringbirthDay">誕生日</param>
        /// <returns>年齢</returns>
        public static int AgeCal(string stringbirthDay)
        {
            int age;
            DateTime birthDay = Convert.ToDateTime(stringbirthDay);
            DateTime today = DateTime.Today;
            age = today.Year - birthDay.Year;
            age -= birthDay > today.AddYears(-age) ? 1 : 0;
            return age;
        }

        /// <summary>
        /// 就学可能な満年齢を計算します。5歳以下は0歳
        /// </summary>
        /// <param name="stringbirthDay">誕生日</param>
        /// <returns>年齢：5歳以下は0歳</returns>
        public static int AgeManCal(string stringbirthDay)
        {
            int age;
            DateTime birthDay = Convert.ToDateTime(stringbirthDay);
            DateTime today = DateTime.Today.AddDays(1);
            DateTime gradeage = Convert.ToDateTime(today.Year + "-04-01");
            age = gradeage.Year - birthDay.Year;
            if (gradeage.Month < birthDay.Month ||
                (gradeage.Month == birthDay.Month &&
                gradeage.Day < birthDay.Day))
            {
                age--;
            }
            if (age < 6)
            {
                age = 0;
            }

            return age;
        }

        /// <summary>
        /// 就学可能満年齢より現在の学年を取得します。
        /// </summary>
        /// <param name="age">就学可能満年齢</param>
        /// <returns>学年</returns>
        public static string GradeCal(int age)
        {
            CramSchoolManagement.Areas.Settings.Models.MastersModel masterdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
            var grade = masterdb.age_m.SingleOrDefault(x => x.age == age);
            return grade.divisions_m.name + grade.grade;
        }

        /// <summary>
        /// 好き苦手マスタ
        /// </summary>
        public static Dictionary<string, long> likedislike_items = new Dictionary<string, long>{
                { "好き", 1 },
                { "苦手", 2 }
        };

    }
}