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

        /// <summary>
        /// クラス内コンストラクタ
        /// マスターアクセス用
        /// </summary>
        private static CramSchoolManagement.Areas.Settings.Models.MastersModel _masterdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();

        /// <summary>
        /// クラス内コンストラクタ
        /// 生徒マスターアクセス用
        /// </summary>
        private static Areas.Students.Models.StudentsModel _studentdb = new Areas.Students.Models.StudentsModel();

        public static DateTime Today()
        {
            TimeZoneInfo tst;

            try
            {
                tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            }
            catch (Exception)
            {
                tst = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");
            }

            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(), tst);
        }

        /// <summary>
        /// 全体のアプリケーションネーム
        /// </summary>
        public static string ApplicationName = "生徒管理システム";


        /// <summary>
        /// ログインしているユーザーの姓名を取得します
        /// </summary>
        /// <returns>姓名</returns>
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

        /// <summary>
        /// 生徒IDより生徒名を取得します
        /// </summary>
        /// <param name="students_id">生徒管理ID</param>
        /// <returns>生徒名</returns>
        //public static string GetStudentName(string students_id)
        //{
        //    var student_person = _studentdb.students_m.Single(students_m => students_m.students_id == students_id);
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
        /// 学校名取得
        /// </summary>
        /// <param name="Id">学校管理ID</param>
        /// <returns>学校名</returns>
        public static string GetSchoolName(long Id)
        {
            var schoolname = _masterdb.schools_m.SingleOrDefault(x => x.school_id == Id);

            if (schoolname != null)
            {
                return schoolname.name;
            }

            return "なし";
        }

        /// <summary>
        /// 教科管理番号から教科名を表示します。
        /// </summary>
        /// <param name="class_id">教科管理番号</param>
        /// <returns>教科名</returns>
        //public static string GetClassName(long? class_id)
        //{
        //    CramSchoolManagement.Areas.Settings.Models.MastersModel masterdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
        //    string className = masterdb.classes_m.Single(x => x.class_id == class_id).display_name.ToString();
        //    return className;
        //}

        /// <summary>
        /// 管理者フラグ ログインユーザーが管理者か判別します
        /// </summary>
        /// <returns></returns>
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
        /// 年齢を計算します。
        /// </summary>
        /// <param name="stringbirthDay">誕生日</param>
        /// <returns>年齢</returns>
        public static int AgeCal(string stringbirthDay)
        {
            int age;
            DateTime birthDay = Convert.ToDateTime(stringbirthDay);
            age = Today().Year - birthDay.Year;
            age -= birthDay > Today().AddYears(-age) ? 1 : 0;
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
            DateTime today = Today().AddDays(1);
            DateTime gradeage = Convert.ToDateTime(today.Year + "-04-01");
            age = gradeage.Year - birthDay.Year;
            if (gradeage.Month < birthDay.Month ||
                (gradeage.Month == birthDay.Month &&
                gradeage.Day < birthDay.Day))
            {
                --age;
            }
            if (today < gradeage)
            {
                --age;
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
            var grade = _masterdb.age_m.SingleOrDefault(x => x.age == age);
            if (grade != null)
            {
                return grade.divisions_m.name + grade.grade;
            }
            return "計算不能";
        }


        /// <summary>
        /// 今月の最初日取得
        /// </summary>
        /// <returns>Date型 月の１日</returns>
        public static DateTime getFDM()
        {
            DateTime dtFDM = new DateTime(Today().Year, Today().Month, 1);
            return dtFDM;
        }

        /// <summary>
        /// 指定年月の最初日取得
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>Date型 月の１日</returns>
        public static DateTime getFDM(int year, int month)
        {
            DateTime dtFDM = new DateTime(year, month, 1);
            return dtFDM;
        }

        /// <summary>
        /// 今月の最終日取得
        /// </summary>
        /// <returns>Date型 月の最終日</returns>
        public static DateTime getLDM()
        {
            DateTime dtLDM = new DateTime(Today().Year, Today().Month, DateTime.DaysInMonth(Today().Year, Today().Month));
            return dtLDM;
        }

        /// <summary>
        /// 指定年月の最終日取得
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>Date型 月の最終日</returns>
        public static DateTime getLDM(int year, int month)
        {
            DateTime dtLDM = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            return dtLDM;
        }


        public static string CheckAttendRate(string students_id, int year, int month)
        {
            

            DateTime dtFDM = new DateTime(year, month, 1);
            DateTime dtLDM = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            // 当月の設定出席回数を取得
            var need_count = _masterdb.atteds_m.SingleOrDefault(x => x.year_month == dtFDM);



            var student_attend = _studentdb.students_attendance.AsEnumerable()
                                 .Where(x => x.attendance_day >= dtFDM && x.attendance_day <= dtLDM && x.students_id == students_id && x.start_time != x.end_time)
                                 ;
            //var month_attend = _masterdb.atteds_m.SingleOrDefault(x => x.year_month == dtFDM);

            //if (student_attend.Count() != 0)
            //{
            //    string studentName = student_attend.FirstOrDefault().students_m.display_name;
            //}



            if (student_attend.Count() != 0 && need_count != null)
            {

                decimal week1 = need_count.g0_count == 0 ? 1 : need_count.g0_count;

                decimal element = need_count.g1_count == 0 ? 1 : need_count.g1_count;

                decimal j12 = need_count.g2_count == 0 ? 1 : need_count.g2_count;

                decimal j3 = need_count.g3_count == 0 ? 1 : need_count.g3_count;

                string gradeName = student_attend.FirstOrDefault().students_m.grade.ToString();
                decimal attend_count = student_attend.Count();
                decimal month_count = getNeccesaryNum(gradeName, week1, element, j12, j3);
                decimal rate = attend_count / month_count * 100;
                return rate.ToString("0.0") + "％";
            }

            return "0%";
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

        public static decimal getNeccesaryNum(string grade, decimal week1, decimal element, decimal j12, decimal j3)
        {
            switch (grade)
            {
                case "中学校１年生":
                    return j12;

                case "中学校２年生":
                    return j12;

                case "中学校３年生":
                    return j3;

                case "週１":
                    return week1;

                default:
                    return element;

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