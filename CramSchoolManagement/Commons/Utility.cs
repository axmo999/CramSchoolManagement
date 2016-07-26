using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using CramSchoolManagement.Areas.Settings.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeForce.Barcodes;
using System.IO;
using CodeForce.Barcodes.Enums;
using ZXing;
using System.Web.Mvc;
using System.Globalization;


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

        public static string GetSchoolName(long Id)
        {
            CramSchoolManagement.Areas.Settings.Models.MastersModel masterdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
            var schoolname = masterdb.schools_m.SingleOrDefault(x => x.school_id == Id);

            if (schoolname != null)
            {
                return schoolname.name;
            }

            return "なし";
        }

        public static bool GetAdminFlg()
        {
            var manager = new UserManager<teachers_m>(new TeacherUserStore());
            var currentUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());
            if (currentUser != null && currentUser.administrator_flag == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 出席確認
        /// </summary>
        /// <param name="id">生徒ID</param>
        /// <returns>1:未出席 2:出席済み 3:退席済み</returns>
        public static int GetAttend( string id )
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            Areas.Students.Models.StudentsModel studentdb = new Areas.Students.Models.StudentsModel();
            var attends = studentdb.students_attendance.SingleOrDefault(x => x.students_id == id && x.attendance_day == today);
            if (attends != null)
            {
                if (attends.end_time != null)
                {
                    return 3;
                }
                return 2;
            }
            return 1;
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
            else if (age > 14)
            {
                age = 15;
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
            if (grade != null)
            {
                return grade.divisions_m.name + grade.grade;
            }
            return "計算不能";
        }

        public static bool CheckIndependent(string students_id)
        {
            Areas.Students.Models.StudentsModel studentdb = new Areas.Students.Models.StudentsModel();
            var indepentent = studentdb.students_independence.OrderByDescending(a => a.week).FirstOrDefault(a => a.students_id == students_id);
            if (indepentent != null)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int weeknum = cal.GetWeekOfYear(DateTime.Parse(indepentent.week), dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                int todaynum = cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                if (weeknum.Equals(todaynum))
                {
                    return false;
                }
            }

            return true;
        }

        public static byte[] GuidToCode39(string guid, int width, int height)
        {
            string GUID = guid.ToString().ToUpper();

            using (MemoryStream stream = new MemoryStream())
            {
                Barcode code39 = new Barcode();
                code39.Encode(TYPE.CODE39, GUID, width, height);
                code39.SaveImage(stream, SaveTypes.PNG);
                return stream.ToArray();
            }
        }

        public static byte[] GuidToCode39(string guid)
        {
            string GUID = guid.ToString().ToUpper();

            using (MemoryStream stream = new MemoryStream())
            {
                var barcodeWriter = new BarcodeWriter();

                barcodeWriter.Format = BarcodeFormat.CODE_39;

                barcodeWriter.Options.Height = 60;
                barcodeWriter.Options.Width = 100;

                barcodeWriter.Options.Margin = 0;

                barcodeWriter.Options.PureBarcode = false;

                using (var bitmap = barcodeWriter.Write(GUID))
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Position = 0;
                }
                return stream.ToArray();
            }

        }

        /// <summary>
        /// 好き苦手マスタ
        /// </summary>
        public static Dictionary<string, long> likedislike_items = new Dictionary<string, long>{
                { "好き", 1 },
                { "苦手", 2 }
        };

        /// <summary>
        /// 評価マスタ
        /// </summary>
        public static IEnumerable<SelectListItem> rate()
        {
            return new List<SelectListItem>()
		        {
			        new SelectListItem() { Value = "1", Text = "★" },
			        new SelectListItem() { Value = "2", Text = "★★" },
			        new SelectListItem() { Value = "3", Text = "★★★" },
                    new SelectListItem() { Value = "4", Text = "★★★★" },
                    new SelectListItem() { Value = "5", Text = "★★★★★" },
		        };
        }

        /// <summary>
        /// 管理者フラグ
        /// </summary>
        public static Dictionary<string, long> admin_flg = new Dictionary<string, long>{
                { "はい", 1 },
                { "いいえ", 0 }
        };

    }
}