namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class teachers_m
    {
        [Key]
        [Display(Name = "�u�t�Ǘ�ID")]
        public string Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "���[�U�[��")]
        public string UserName { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "�p�X���[�h")]
        public string teachers_password { get; set; }

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

        [Required]
        [Display(Name = "����")]
        public long gender_id { get; set; }

        [StringLength(2147483647)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "���l")]
        public string note { get; set; }

        [Required]
        [Display(Name = "�Ǘ��҃t���O")]
        public long administrator_flag { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual gender_m gender_m { get; set; }
    }
}
