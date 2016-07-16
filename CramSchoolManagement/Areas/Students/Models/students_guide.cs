namespace CramSchoolManagement.Areas.Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students_guide
    {
        [Key]
        [Display(Name = "成績管理番号")]
        public long students_guide_id { get; set; }

        [Display(Name = "生徒管理番号")]
        public long students_id { get; set; }

        [Display(Name = "生徒指導日")]
        [DataType(DataType.Date)]
        public string guide_date { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "講師管理番号")]
        public string Id { get; set; }

        [Display(Name = "教科管理番号")]
        public long class_id { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "指導内容")]
        public string guide_contents { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.teachers_m teachers_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.classes_m classes_m { get; set; }
    }
}
