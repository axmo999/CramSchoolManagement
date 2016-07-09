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
        [Display(Name = "ŠwZŠÇ—”Ô†")]
        public long school_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "ŠwZ–¼")]
        public string name { get; set; }

        [Required]
        [Display(Name = "ŠwZ‹æ•ª")]
        public long? division_id { get; set; }

        [Display(Name = "—X•Ö”Ô†")]
        public string postal_code { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "ZŠ")]
        public string address { get; set; }

        [Display(Name = "˜A—æ")]
        public string phone_number { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }
    }
}
