namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class divisions_m
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public divisions_m()
        {
            schools_m = new HashSet<schools_m>();
            classes_m = new HashSet<classes_m>();
        }

        [Key]
        [Display(Name = "学校区分管理番号")]
        public long division_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "学校区分名")]
        public string name { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schools_m> schools_m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<classes_m> classes_m { get; set; }
    }
}
