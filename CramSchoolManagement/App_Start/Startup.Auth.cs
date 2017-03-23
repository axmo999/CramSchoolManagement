using CramSchoolManagement.App_Start;
using CramSchoolManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace CramSchoolManagement
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {

            // アプリケーションが Cookie を使用して、サインインしたユーザーの情報を格納できるようにします
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/Login")
            });

            //app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        }
    }
}