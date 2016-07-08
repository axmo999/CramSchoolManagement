namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class classes_m
    {
        [Key]
        [Display(Name = "���ȊǗ��ԍ�")]
        public long class_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "���Ȗ�")]
        public string name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "���ȉp�ꖼ")]
        public string eng_name { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }
    }
}
