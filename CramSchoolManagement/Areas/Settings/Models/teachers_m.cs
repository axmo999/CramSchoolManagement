namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class teachers_m
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

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "姓")]
        public string last_name { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "名")]
        public string first_name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "ミドルネーム")]
        public string middle_name { get; set; }

        [Required]
        [Display(Name = "性別")]
        public long gender_id { get; set; }

        [StringLength(2147483647)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "備考")]
        public string note { get; set; }

        [Required]
        [Display(Name = "管理者フラグ")]
        public long administrator_flag { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual gender_m gender_m { get; set; }
    }
}
