using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

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

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

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

    public class TeacherUserStore : IUserStore<teachers_m>, IUserPasswordStore<teachers_m>
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

    }

}
