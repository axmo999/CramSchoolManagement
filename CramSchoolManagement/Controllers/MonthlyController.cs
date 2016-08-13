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

        // GET: Index

        public ActionResult Index()
        {
            var year_group = studentdb
                            .students_attendance
                            .GroupBy(x => x.attendance_day.Year)
                            .Select(x => x.Key)
                            .ToList();

            //var attend_date_year_group = from studentdb.students_attendance

            SelectList YearList = new SelectList(year_group);

            ViewBag.year = YearList;

            return View();
        }

        public ActionResult GetMonth(int Year)
        {
            var month_group = studentdb
                        .students_attendance
                        .Where(x => x.attendance_day.Year == Year)
                        .GroupBy(x => x.attendance_day.Month)
                        .Select(x => x.Key)
                        .ToList();

            SelectList MonthList = new SelectList(month_group);

            return Json(MonthList, JsonRequestBehavior.AllowGet);
        }


        // GET: Monthly
        [HttpPost]
        public ActionResult Print(int year, int month)
        {
            // 変数より月の最初と最終日を設定
            DateTime FDM = CramSchoolManagement.Commons.Utility.getFDM(year, month);
            DateTime LDM = CramSchoolManagement.Commons.Utility.getLDM(year, month);

            // 当月の出席リストを取得
            var student_attend_list = studentdb
                                .students_attendance
                                .Where(x => x.attendance_day >= FDM && x.attendance_day <= LDM)
                                .Include(s => s.students_m);

            ViewBag.students_attend_list = student_attend_list;

            // 出席リストより生徒を抽出
            var students_list = student_attend_list.Select(x => x.students_id).Distinct().ToArray();

            // 生徒リストより指導リストを作成
            var students_guid = studentdb
                                .students_guide
                                .Where(x => students_list.Contains(x.students_id) &&
                                x.guide_date >= FDM && x.guide_date <= LDM
                                ).ToList();

            ViewBag.students_guid_list = students_guid;

            var student_independence = studentdb
                                        .students_independence
                                        .Where(x => students_list.Contains(x.students_id) &&
                                        x.week >= FDM && x.week <= LDM
                                        );

            ViewBag.student_independence_list = student_independence;

            ViewBag.this_year = year;
            ViewBag.this_month = month;

            return View();
        }
    }
}