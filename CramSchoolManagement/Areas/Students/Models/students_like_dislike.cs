namespace CramSchoolManagement.Areas.Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students_like_dislike
    {
        [Key]
        [Display(Name = "D‚«Œ™‚¢ŠÇ—”Ô†")]
        public long students_like_dislike_id { get; set; }

        [Display(Name = "¶“kŠÇ—”Ô†")]
        public long students_id { get; set; }

        [Display(Name = "‹³‰ÈŠÇ—”Ô†")]
        public long class_id { get; set; }

        [Display(Name = "D‚«or‹êè")]
        public long like_dislike { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.classes_m classes_m { get; set; }
    }
}
