namespace CramSchoolManagement.Areas.Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class monthly_reports
    {
        [Key]
        [Display(Name = "月次レポート管理番号")]
        public long monthly_report_id { get; set; }

        [Display(Name = "月次レポート入力日")]
        [DataType(DataType.Date)]
        public DateTime monthly_report_date { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "講師管理番号")]
        public string Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "生徒管理番号")]
        public string students_id { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "学習面内容")]
        public string study_contents { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "生活面内容")]
        public string life_contents { get; set; }

        public string create_user { get; set; }

        public DateTime create_date { get; set; }

        public string update_user { get; set; }

        public DateTime update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.teachers_m teachers_m { get; set; }
    }
}
