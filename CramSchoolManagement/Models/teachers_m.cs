using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace CramSchoolManagement.Models
{
    public class teachers_m : IUser<string>
    {
        public string Id { get; set; }

        //public long teachers_id { get; set; }

        [Required]
        [Display(Name = "ユーザー名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string teachers_password { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }

        //public teachers_m()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}

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
            using (var context = new ApplicationDbContext())
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
            using (var context = new ApplicationDbContext())
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