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
        public long students_guide_id { get; set; }

        public long students_id { get; set; }

        public DateTime? guide_date { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string teachers_id { get; set; }

        public long clasees_id { get; set; }

        [StringLength(2147483647)]
        public string guide_contents { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string create_user { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string create_date { get; set; }

        [StringLength(2147483647)]
        public string update_user { get; set; }

        [StringLength(2147483647)]
        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }
    }
}
