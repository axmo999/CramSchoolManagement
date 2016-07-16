namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class exams_m
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public exams_m()
        {
            students_grade = new HashSet<CramSchoolManagement.Areas.Students.Models.students_grade>();
        }

        [Key]
        [Display(Name = "テスト区分管理番号")]
        public long exam_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "テスト区分名")]
        public string name { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_grade> students_grade { get; set; }
    }
}
