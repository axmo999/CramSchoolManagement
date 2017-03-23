namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class atteds_m
    {
        [Key]
        [Display(Name = "出席月管理番号")]
        public int attend_id { get; set; }

        //[Required]
        //[Display(Name = "出席グループ番号")]
        //public int group_id { get; set; }

        [Required]
        [Display(Name = "出席月")]
        public DateTime year_month { get; set; }

        [Required]
        [Display(Name = "週一出席回数")]
        public int g0_count { get; set; }

        [Required]
        [Display(Name = "小学生出席回数")]
        public int g1_count { get; set; }

        [Required]
        [Display(Name = "中１，２出席回数")]
        public int g2_count { get; set; }

        [Required]
        [Display(Name = "中３出席回数")]
        public int g3_count { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        //public virtual CramSchoolManagement.Areas.Settings.Models.attend_group_m attend_group_m { get; set; }

    }
}
