using CramSchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CramSchoolManagement.Controllers
{
    public class MonthlyController : Controller
    {
        /// <summary>生徒マスタ情報コンテキスト</summary>
        private Students_mModel student_m_db = new Students_mModel();

        /// <summary>生徒登録情報コンテキスト</summary>
        private CramSchoolManagement.Areas.Students.Models.StudentsModel studentdb = new Areas.Students.Models.StudentsModel();

        /// <summary>設定情報コンテキスト</summary>
        private CramSchoolManagement.Areas.Settings.Models.MastersModel setdb = new CramSchoolManagement.Areas.Settings.Models.MastersModel();

        /// <summary>環境依存対応Today</summary>
        private DateTime _today = CramSchoolManagement.Commons.Utility.Today();


        // GET: Monthly
        public ActionResult Index(int year, int month)
        {
            // 変数より月の最初と最終日を設定
            DateTime FDM = CramSchoolManagement.Commons.Utility.getFDM(year, month);
            DateTime LDM = CramSchoolManagement.Commons.Utility.getLDM(year, month);

            // 当月の出席リストを取得
            var student_attend_list = studentdb
                                .students_attendance
                                .Where(x => x.attendance_day >= FDM && x.attendance_day <= LDM)
                                .Include(s => s.students_m);

            string[] students_list = student_attend_list.Select(x => x.students_id).Distinct().ToArray();

            // 出席リストより指導リストを作成
            var student_guid = student_attend_list.Include(x => x.students_m.students_guide).Select(x => x.students_m.students_guide).ToList();

            //var student_guid_lsit = student_guid.Where(s => s >= FDM && s.guide_date <= LDM);

            ViewBag.student_independence_list = student_attend_list.Select(x => x.students_m.students_independence).ToList();

            ViewBag.this_year = year;
            ViewBag.this_month = month;

            return View();
        }
    }
}