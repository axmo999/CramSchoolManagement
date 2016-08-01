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
        [Display(Name = "教科管理番号")]
        public long class_id { get; set; }

        [Required]
        [Display(Name = "学校区分管理番号")]
        public long division_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "教科名")]
        public string name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "教科英語名")]
        public string eng_name { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_like_dislike> students_like_dislike { get; set; }

        [Display(Name = "教科名")]
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
            return divisionName + Environment.NewLine + name;
        }
    }
}
