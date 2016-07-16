namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public class age_m
    {

        [Key]
        [Display(Name = "学年管理番号")]
        public long age_id { get; set; }

        [Required]
        [Display(Name = "年齢")]
        public int age { get; set; }

        [Required]
        [Display(Name = "学校区分管理番号")]
        public long division_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        [Display(Name = "学年名")]
        public string grade { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        public virtual divisions_m divisions_m { get; set; }

        [Display(Name = "表示名")]
        public string display_name
        {
            get
            {
                return GetGradeDisplay();
            }
        }

        public string GetGradeDisplay()
        {
            CramSchoolManagement.Areas.Settings.Models.MastersModel MasterDB = new CramSchoolManagement.Areas.Settings.Models.MastersModel();
            string divisionName = MasterDB.divisions_m.Single(x => x.division_id == division_id).name.ToString();
            return divisionName + grade;
        }

    }
}