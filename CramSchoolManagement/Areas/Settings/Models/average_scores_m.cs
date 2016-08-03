namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class average_scores_m
    {
        [Key]
        [Display(Name = "平均成績管理番号")]
        public long average_id { get; set; }

        [Display(Name = "試験日")]
        [DataType(DataType.Date)]
        public DateTime exam_date { get; set; }

        [Display(Name = "試験区分")]
        public long exam_id { get; set; }

        [Display(Name = "教科番号")]
        public long class_id { get; set; }

        [Display(Name = "試験点数")]
        public long exam_scores { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.exams_m exams_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.classes_m classes_m { get; set; }
    }
}
