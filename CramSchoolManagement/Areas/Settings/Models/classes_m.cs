namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class classes_m
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public classes_m()
        {
            students_like_dislike = new HashSet<CramSchoolManagement.Areas.Students.Models.students_like_dislike>();
        }

        [Key]
        [Display(Name = "ã≥â»ä«óùî‘çÜ")]
        public long class_id { get; set; }

        [Required]
        [Display(Name = "äwçZãÊï™ä«óùî‘çÜ")]
        public long division_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "ã≥â»ñº")]
        public string name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "ã≥â»âpåÍñº")]
        public string eng_name { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_like_dislike> students_like_dislike { get; set; }

        [Display(Name = "ã≥â»ñº")]
        public string display_name
        {
            get
            {
                return displayClassName();
            }
        }

        private string displayClassName()
        {
            MastersModel MasterDB = new MastersModel();
            string divisionName = MasterDB.divisions_m.Single(x => x.division_id == division_id).name.ToString();
            return divisionName + " " + name;
        }
    }
}
