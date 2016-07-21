using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Diagnostics;

namespace CramSchoolManagement.Areas.Settings.Models
{

    public partial class teachers_m : IUser<string>
    {

        [Key]
        [Display(Name = "講師管理ID")]
        public string Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "ユーザー名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "パスワード")]
        public string teachers_password { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "姓")]
        public string last_name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "名")]
        public string first_name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "ミドルネーム")]
        public string middle_name { get; set; }

        [Display(Name = "性別")]
        public long gender_id { get; set; }

        [StringLength(2147483647)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "備考")]
        public string note { get; set; }

        [Display(Name = "管理者フラグ")]
        public long administrator_flag { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        public virtual gender_m gender_m { get; set; }

        [Display(Name = "講師名")]
        public string display_name
        {
            get
            {
                return teacherName();
            }
        }

        public string teacherName()
        {
            string teacherName = string.Empty;
            if (last_name != null)
            {
                teacherName = last_name.ToString();
            }

            if (middle_name != null)
            {
                teacherName += " " + middle_name.ToString();
            }

            if (first_name != null)
            {
                teacherName += " " + first_name.ToString();
            }
            return teacherName;
        }

        public string display_admin
        {
            get
            {
                return searchadmin();
            }
        }

        private string searchadmin()
        {
            string admin = string.Empty;

            if (administrator_flag == 1)
            {
                admin = "はい";
            }
            else
            {
                admin = "";
            }

            return admin;

        }

    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "現在のパスワード")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} の長さは、{2} 文字以上である必要があります。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新しいパスワード")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "新しいパスワードの確認入力")]
        [Compare("NewPassword", ErrorMessage = "新しいパスワードと確認のパスワードが一致しません。")]
        public string ConfirmPassword { get; set; }
    }

    public class TeacherUserStore : 
        IUserStore<teachers_m>, 
        IUserPasswordStore<teachers_m>
        //IUserRoleStore<teachers_m, string> 
        //IRoleStore<ApplicationRole, string>
    {
        private static List<teachers_m> users = new List<teachers_m>
        {
            //new teachers_m { Id = "user1-id", UserName = "user1" }
        };

        public Task<teachers_m> FindByNameAsync(string userName)
        {
            using (var context = new MastersModel())
            {
                var users = from u in context.teachers_m
                            where u.UserName == userName
                            select u;
                return Task.FromResult(users.FirstOrDefault());
            }
            //return Task.FromResult(users.FirstOrDefault(u => u.UserName == userName));
        }

        public Task CreateAsync(teachers_m user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(teachers_m user)
        {
            var target = await this.FindByIdAsync(user.Id);
            if (target == null)
            {
                return;
            }

            users.Remove(target);
        }

        public Task<teachers_m> FindByIdAsync(string userId)
        {
            using (var context = new MastersModel())
            {
                var users = from u in context.teachers_m
                            where u.Id == userId
                            select u;
                return Task.FromResult(users.FirstOrDefault());
            }
        }

        public async Task UpdateAsync(teachers_m user)
        {
            var target = await this.FindByIdAsync(user.Id);
            if (target == null)
            {
                return;
            }

            target.UserName = user.UserName;
        }

        public void Dispose()
        {
            //例外は出ないようにNotImplementedExceptionは消しておく
        }

        public Task<string> GetPasswordHashAsync(teachers_m user)
        {
            return Task.FromResult(new PasswordHasher().HashPassword(user.UserName));
        }

        public Task<bool> HasPasswordAsync(teachers_m user)
        {
            return Task.FromResult(true);
        }

        public Task SetPasswordHashAsync(teachers_m user, string passwordHash)
        {
            return Task.Delay(0);
        }

        //private static List<ApplicationRole> Roles = new List<ApplicationRole>();

        //private static List<Tuple<string, string>> UserRoleMap = new List<Tuple<string, string>>();
        ///// <summary>
        ///// ユーザーをロールに追加する
        ///// </summary>
        //public Task AddToRoleAsync(teachers_m user, string roleName)
        //{
        //    //Debug.WriteLine(nameof(AddToRoleAsync));

        //    var role = Roles.FirstOrDefault(x => x.Name == roleName);
        //    if(role == null){ throw new InvalidOperationException(); }

        //    var userRoleMap = UserRoleMap.FirstOrDefault(x => x.Item1 == user.Id && x.Item2 == role.Id);
        //    if(userRoleMap == null)
        //    {
        //        UserRoleMap.Add(Tuple.Create(user.Id, role.Id));
        //    }

        //    return Task.FromResult(default(object));
        //}

        ///// <summary>
        ///// ユーザーのロールを取得する
        ///// </summary>
        //public Task<IList<string>> GetRolesAsync(teachers_m user)
        //{
        //    //Debug.WriteLine(nameof(GetRolesAsync));
        //    IList<string> roleNames = UserRoleMap.Where(x => x.Item1 == user.Id).Select(x => x.Item2)
        //        .Select(x => Roles.First(y => y.Id == x))
        //        .Select(x => x.Name)
        //        .ToList();
        //    return Task.FromResult(roleNames);
        //}

        ///// <summary>
        ///// ユーザーがロールに所属するか
        ///// </summary>
        //public async Task<bool> IsInRoleAsync(teachers_m user, string roleName)
        //{
        //    //Debug.WriteLine(nameof(IsInRoleAsync));
        //    var roles = await this.GetRolesAsync(user);
        //    return roles.FirstOrDefault(x => x.ToUpper() == roleName.ToUpper()) != null;
        //}

        ///// <summary>
        ///// ユーザーをロールから削除する
        ///// </summary>
        //public Task RemoveFromRoleAsync(teachers_m user, string roleName)
        //{
        //    //Debug.WriteLine(nameof(RemoveFromRoleAsync));
        //    var role = Roles.FirstOrDefault(x => x.Name == roleName);
        //    if (role == null) { return Task.FromResult(default(object)); }
        //    var userRoleMap = UserRoleMap.FirstOrDefault(x => x.Item1 == user.Id && x.Item2 == role.Id);
        //    if (userRoleMap != null)
        //    {
        //        UserRoleMap.Remove(userRoleMap);
        //    }
        //    return Task.FromResult(default(object));
        //}

        ///// <summary>
        ///// ロールを作成します。
        ///// </summary>
        //public Task CreateAsync(ApplicationRole role)
        //{
        //    //Debug.WriteLine(nameof(CreateAsync) + " role");
        //    Roles.Add(role);
        //    return Task.FromResult(default(object));
        //}

        ///// <summary>
        ///// ロールを更新します
        ///// </summary>
        //public Task UpdateAsync(ApplicationRole role)
        //{
        //    //Debug.WriteLine(nameof(UpdateAsync) + " role");
        //    var r = Roles.FirstOrDefault(x => x.Id == role.Id);
        //    if (r == null) { return Task.FromResult(default(object)); }
        //    r.Name = role.Name;
        //    return Task.FromResult(default(object));
        //}

        ///// <summary>
        ///// ロールを削除します
        ///// </summary>
        //public Task DeleteAsync(ApplicationRole role)
        //{
        //    //Debug.WriteLine(nameof(DeleteAsync) + " role");
        //    var r = Roles.FirstOrDefault(x => x.Id == role.Id);
        //    if (r == null) { return Task.FromResult(default(object)); }
        //    Roles.Remove(r);
        //    return Task.FromResult(default(object));
        //}

        ///// <summary>
        ///// ロールをIDで取得します。
        ///// </summary>
        //Task<ApplicationRole> IRoleStore<ApplicationRole, string>.FindByIdAsync(string roleId)
        //{
        //    //Debug.WriteLine(nameof(FindByIdAsync) + " role");
        //    var r = Roles.FirstOrDefault(x => x.Id == roleId);
        //    return Task.FromResult(r);
        //}

        ///// <summary>
        ///// ロールを名前で取得します。
        ///// </summary>
        //Task<ApplicationRole> IRoleStore<ApplicationRole, string>.FindByNameAsync(string roleName)
        //{
        //    //Debug.WriteLine(nameof(FindByNameAsync) + " role");
        //    var r = Roles.FirstOrDefault(x => x.Name == roleName);
        //    return Task.FromResult(r);
        //}

    }

    //public class ApplicationRole : IdentityRole
    //{
    //    public ApplicationRole()
    //        : base()
    //    {
    //    }

    //    public ApplicationRole(string pRoleName)
    //        : base(pRoleName)
    //    {
    //    }
    //}

}
