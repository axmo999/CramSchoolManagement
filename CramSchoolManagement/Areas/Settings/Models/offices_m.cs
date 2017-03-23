namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class offices_m
    {
        [Key]
        [Display(Name = "教室管理番号")]
        public long office_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "教室名")]
        public string name { get; set; }

        [Display(Name = "郵便番号")]
        public string postal_code { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "住所")]
        public string address { get; set; }

        [Display(Name = "連絡先")]
        public string phone_number { get; set; }

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
