namespace CramSchoolManagement.Models
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using CramSchoolManagement.Commons;

    public partial class tweet
    {
        [Key]
        [Display(Name = "つぶやき管理番号")]
        public long tweet_id { get; set; }

        [Required]
        [Display(Name = "講師管理番号")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "教室管理番号")]
        public long office_id { get; set; }

        [Display(Name = "つぶやき投稿日")]
        [DataType(DataType.Date)]
        public DateTime tweet_date { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "つぶやく")]
        public string tweet_comment { get; set; }

        public string create_user { get; set; }

        public DateTime create_date { get; set; }

        public string update_user { get; set; }

        public DateTime update_date { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.teachers_m teachers_m { get; set; }
    }
}
