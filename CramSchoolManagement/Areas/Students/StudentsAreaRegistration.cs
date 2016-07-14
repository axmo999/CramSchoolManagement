using System.Web.Mvc;

namespace CramSchoolManagement.Areas.Students
{
    public class StudentsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Students";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Students_id_route",
                "Students/{students_id}/{controller}/{action}/{num}",
                new { action = "Index", num = UrlParameter.Optional }
            );

            //context.MapRoute(
            //    "Students_default",
            //    "Students/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional}
            //);
        }
    }
}