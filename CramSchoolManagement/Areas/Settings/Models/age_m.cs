namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class age_m
    {

        [Key]
        [Display(Name = "学年管理番号")]
        public long age_id { get; set; }

        [Required]
        [Display(Name = "年齢")]
        public int age { get; set; }

        [Required]
        [Display(Name = "学校区分管理番号")]
        public long division_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "学年名")]
        public string grade { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }

    }
}