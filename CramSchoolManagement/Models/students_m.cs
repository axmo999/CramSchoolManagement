namespace CramSchoolManagement.Models
{
//using CramSchoolManagement.Areas.Students.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

    public partial class students_m
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public students_m()
        {
            students_attendance = new HashSet<CramSchoolManagement.Areas.Students.Models.students_attendance>();
            students_grade = new HashSet<CramSchoolManagement.Areas.Students.Models.students_grade>();
            students_guide = new HashSet<CramSchoolManagement.Areas.Students.Models.students_guide>();
            students_like_dislike = new HashSet<CramSchoolManagement.Areas.Students.Models.students_like_dislike>();
        }

        [Key]
        [Display(Name = "���k�Ǘ��ԍ�")]
        public long students_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "��")]
        public string last_name { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "��")]
        public string first_name { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "�~�h���l�[��")]
        public string middle_name { get; set; }

        [Display(Name = "�w�Z�Ǘ��ԍ�")]
        public long school_id { get; set; }

        [Display(Name = "����")]
        public long gender_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "�a����")]
        [DataType(DataType.Date)]
        public string birthday { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "�X�֔ԍ�")]
        public string postal_code { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "�Z��")]
        public string address { get; set; }

        [StringLength(2147483647)]
        [Display(Name = "�d�b�ԍ�")]
        public string phone_number { get; set; }

        [Display(Name = "��]�Z")]
        public long hope_school { get; set; }

        [Display(Name = "���w�Z")]
        public long enter_school { get; set; }

        [StringLength(2147483647)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "���l")]
        public string note { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.gender_m gender_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.schools_m schools_m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_attendance> students_attendance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_grade> students_grade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_guide> students_guide { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CramSchoolManagement.Areas.Students.Models.students_like_dislike> students_like_dislike { get; set; }
        
        [Display(Name = "�\����")]
        public string display_name
        {
            get
            {
                return studentName();
            }
        }

        [Display(Name = "�w�N")]
        public string grade
        {
            get
            {
                return CramSchoolManagement.Commons.Utility.GradeCal(birthday);
            }
        }

        public string studentName()
        {
            string studentName = string.Empty;
            if (last_name != null)
            {
                studentName = last_name.ToString();
            }

            if (middle_name != null)
            {
                studentName += " " + middle_name.ToString();
            }

            if (first_name != null)
            {
                studentName += " " + first_name.ToString();
            }
            return studentName;
        }

        public virtual ICollection<students_face> students_face { get; set; }

        //public virtual ICollection<CramSchoolManagement.Areas.Settings.Models.age_m> age_m { get; set; }
    }
}
