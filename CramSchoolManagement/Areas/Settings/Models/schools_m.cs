namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class schools_m
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public schools_m()
        {
            students_m = new HashSet<students_m>();
            students_m1 = new HashSet<students_m>();
            students_m2 = new HashSet<students_m>();
        }

        [Key]
        [Display(Name = "äwçZä«óùî‘çÜ")]
        public long school_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "äwçZñº")]
        public string name { get; set; }

        [Required]
        [Display(Name = "äwçZãÊï™")]
        public long? division_id { get; set; }

        [Display(Name = "óXï÷î‘çÜ")]
        public string postal_code { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "èZèä")]
        public string address { get; set; }

        [Display(Name = "òAóçêÊ")]
        public string phone_number { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<students_m> students_m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<students_m> students_m1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<students_m> students_m2 { get; set; }
    }
}
