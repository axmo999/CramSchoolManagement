namespace CramSchoolManagement.Areas.Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students_grade
    {
        [Key]
        [Display(Name = "���ъǗ��ԍ�")]
        public long students_grade_id { get; set; }

        [Display(Name = "���k�Ǘ��ԍ�")]
        public long students_id { get; set; }

        [Display(Name = "������")]
        [DataType(DataType.Date)]
        public string exam_date { get; set; }

        [Display(Name = "�����敪")]
        public long exam_id { get; set; }

        [Display(Name = "���Ȕԍ�")]
        public long class_id { get; set; }

        [Display(Name = "�����_��")]
        public long exam_scores { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.exams_m exams_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.classes_m classes_m { get; set; }
    }
}