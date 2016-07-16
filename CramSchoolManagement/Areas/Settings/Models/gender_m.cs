namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class gender_m
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gender_m()
        {
            teachers_m = new HashSet<teachers_m>();
        }

        [Key]
        [Display(Name = "性別管理番号")]
        public long gender_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "性別名")]
        public string gender_name { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teachers_m> teachers_m { get; set; }
    }
}
