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
        [Display(Name = "¬ÑŠÇ—”Ô†")]
        public long students_guide_id { get; set; }

        [Display(Name = "¶“kŠÇ—”Ô†")]
        public long students_id { get; set; }

        [Display(Name = "¶“kw“±“ú")]
        [DataType(DataType.Date)]
        public string guide_date { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "utŠÇ—”Ô†")]
        public string Id { get; set; }

        [Display(Name = "‹³‰ÈŠÇ—”Ô†")]
        public long class_id { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "w“±“à—e")]
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
