namespace CramSchoolManagement.Areas.Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students_attendance
    {
        [Key]
        [Display(Name = "出席管理番号")]
        public long students_attendance_id { get; set; }

        [Display(Name = "生徒管理番号")]
        public long students_id { get; set; }

        [Display(Name = "出席日")]
        [DataType(DataType.Date)]
        public string attendance_day { get; set; }

        [Display(Name = "開始時間")]
        [DataType(DataType.Time)]
        public string start_time { get; set; }

        [Display(Name = "終了時間")]
        [DataType(DataType.Time)]
        public string end_time { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }
    }
}
