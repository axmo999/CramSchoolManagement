using CramSchoolManagement.Areas.Settings.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CramSchoolManagement.App_Start
{
    public class IdentityConfig
    {
    }

    //public class ApplicationRoleManager : RoleManager<ApplicationRole, string>
    //{
    //    public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
    //        : base("name=CsmModels") { }

    //    public static ApplicationRoleManager Create(
    //      IdentityFactoryOptions<ApplicationRoleManager> options,
    //      IOwinContext context)
    //    {
    //        //（1）DbContext取得
    //        var dbContext = context.Get<MastersModel>();
    //        //（2）ロールストア作成
    //        var roleStore = new RoleStore<ApplicationRole>(dbContext);
    //        //（3）ロールマネージャー作成
    //        var manager = new ApplicationRoleManager(roleStore);

    //        if (!manager.Roles.Any())
    //        {
    //            //（4）初回に管理者ロールを作成する
    //            manager.Create(new ApplicationRole
    //            {
    //                Name = "Administrator"
    //            });
    //        }
    //        return manager;
    //    }
    //}
}