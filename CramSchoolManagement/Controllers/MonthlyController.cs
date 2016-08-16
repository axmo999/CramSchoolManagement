using CramSchoolManagement.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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

        //ReportDataSource rd;

        //LocalReport lr;

        // GET: Index

        public ActionResult Index(int? Year)
        {
            var year_group = studentdb
                            .students_attendance
                            .GroupBy(x => x.attendance_day.Year)
                            .Select(x => x.Key)
                            .ToList();

            //var attend_date_year_group = from studentdb.students_attendance

            SelectList YearList = new SelectList(year_group);

            ViewBag.year = YearList;

            if (Year != null)
            {
                var month_group = studentdb
                        .students_attendance
                        .Where(x => x.attendance_day.Year == Year)
                        .GroupBy(x => x.attendance_day.Month)
                        .Select(x => x.Key)
                        .ToList();

                SelectList MonthList = new SelectList(month_group);

                ViewBag.month = MonthList;
            }


            return View();
        }


        // GET: Monthly
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
                                .Where(x => 
                                x.guide_date >= FDM && x.guide_date <= LDM
                                ).ToList();

            ViewBag.students_guid_list = students_guid;

            var student_independence = studentdb
                                        .students_independence
                                        .Where(x => students_list.Contains(x.students_id) &&
                                        x.week >= FDM && x.week <= LDM
                                        ).ToList();

            ViewBag.student_independence_list = student_independence;

            ViewBag.this_year = year;
            ViewBag.this_month = month;

            return View();
        }

        public ActionResult GetReport(int year, int month)
        {
            try
            {
                //lr = new LocalReport();
                string reportPath = null;
                reportPath = Path.Combine(Server.MapPath("~/Reports/StudentMonthlyAttend.rdlc"));
                //lr.ReportPath = reportPath;

                DateTime FDM = CramSchoolManagement.Commons.Utility.getFDM(year, month);
                DateTime LDM = CramSchoolManagement.Commons.Utility.getLDM(year, month);

                // 当月の設定出席回数を取得
                Decimal attend_count = setdb.atteds_m.SingleOrDefault(x => x.year_month == FDM).count;

                // 当月の出席リストを取得
                var student_attend_list = studentdb
                                    .students_attendance
                                    .Where(x => x.attendance_day >= FDM && x.attendance_day <= LDM)
                                    .Include(s => s.students_m)
                                    .GroupBy(x => x.students_id)
                                    .Select(x => new { name = x.FirstOrDefault().students_m, count = x.Count().ToString() })
                                    .ToList()
                                    .Select(x => new { name = x.name.display_name, count = x.count, per = Convert.ToDecimal(x.count) / attend_count * 100 + "%" })
                                    .ToList();

                //rd = new ReportDataSource("DataSet1", student_attend);
                //lr.DataSources.Add(rd);

                ReportViewer rptViewer = new ReportViewer();
                rptViewer.ProcessingMode = ProcessingMode.Local;

                rptViewer.LocalReport.ReportPath = reportPath;
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dataTable", student_attend_list));

                ViewBag.Report = rptViewer;

            }
            catch (Exception ex)
            {
                return View();
            }

            //string reportType = "pdf";
            //string mimeType;
            //string encoding;
            //string fileNameExtension;

            //string deviceInfo =

            //"<DeviceInfo>" +

            //"  <OutputFormat>" + reportType + "</OutputFormat>" +

            //"  <PageWidth>11.5in</PageWidth>" +

            //"  <PageHeight>8.30in</PageHeight>" +

            //"  <MarginTop>0in</MarginTop>" +

            //"  <MarginLeft>0in</MarginLeft>" +

            //"  <MarginRight>0in</MarginRight>" +

            //"  <MarginBottom>0in</MarginBottom>" +

            //"</DeviceInfo>";

            //Warning[] warnings;

            //string[] streams;

            //byte[] renderedBytes;

            //renderedBytes = lr.Render(

            //    reportType,

            //    deviceInfo,

            //    out mimeType,

            //    out encoding,

            //    out fileNameExtension,

            //    out streams,

            //    out warnings);

            return View();

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                student_m_db.Dispose();
                studentdb.Dispose();
                setdb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}