using System.Web;
using System.Web.Optimization;

namespace CramSchoolManagement
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery-2.2.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new StyleBundle("~/Content/honoka/css").Include(
                        "~/Content/themes/honoka/css/bootstrap.css"
                ));

            bundles.Add(new ScriptBundle("~/Content/honoka/js").Include(
                        "~/Content/themes/honoka/js/bootstrap.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css"
                ));

            bundles.Add(new ScriptBundle("~/Content/raty").Include(
                        "~/Content/raty/jquery.raty.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/table").Include(
                        "~/Scripts/jquery.table_transpose.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/DataTablesjs").Include(
                        "~/Content/DataTables/datatables.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/DataTablescss").Include(
                        "~/Content/DataTables/datatables.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jTrunc").Include(
                        "~/Scripts/jquery.jtruncsubstr-1.0rc.js",
                        "~/Scripts/jglycy-1.0.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                        "~/Content/chart/Chart.bundle.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/print").Include(
                        "~/Content/print.css"
                ));

            bundles.Add(new ScriptBundle("~/Content/knockout").Include(
                        "~/Content/knockout/knockout-3.4.0.js"
                ));
        }
    }
}