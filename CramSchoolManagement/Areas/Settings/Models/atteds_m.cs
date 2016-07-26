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

        [Required]
        [Display(Name = "出席月")]
        public DateTime year_month { get; set; }

        [Required]
        [Display(Name = "出席回数")]
        public int count { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

    }
}
