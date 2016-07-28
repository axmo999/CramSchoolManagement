using System.Web;
using System.Web.Optimization;

namespace CramSchoolManagement
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery-{version}.js"));

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

            bundles.Add(new ScriptBundle("~/Content/DataTables").Include(
                        "~/Content/DataTables/datatables.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/DataTables").Include(
                        "~/Content/DataTables/datatables.css"
                ));

        }
    }
}