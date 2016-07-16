namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class schools_m
    {
        [Key]
        [Display(Name = "学校管理番号")]
        public long school_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "学校名")]
        public string name { get; set; }

        [Required]
        [Display(Name = "学校区分")]
        public long? division_id { get; set; }

        [Display(Name = "郵便番号")]
        public string postal_code { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "住所")]
        public string address { get; set; }

        [Display(Name = "連絡先")]
        public string phone_number { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }
    }
}
