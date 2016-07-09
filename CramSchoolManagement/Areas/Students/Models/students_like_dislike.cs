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
        public long students_like_dislike_id { get; set; }

        public long students_id { get; set; }

        public long classes_id { get; set; }

        public long like_dislike { get; set; }

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
