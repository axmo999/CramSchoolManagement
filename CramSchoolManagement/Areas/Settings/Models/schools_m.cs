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
        [Display(Name = "�w�Z�Ǘ��ԍ�")]
        public long school_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "�w�Z��")]
        public string name { get; set; }

        [Required]
        [Display(Name = "�w�Z�敪")]
        public long? division_id { get; set; }

        [Display(Name = "�X�֔ԍ�")]
        public string postal_code { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "�Z��")]
        public string address { get; set; }

        [Display(Name = "�A����")]
        public string phone_number { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }
    }
}
