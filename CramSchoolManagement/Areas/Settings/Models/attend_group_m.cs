namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public class attend_group_m
    {

        [Key]
        [Column(Order = 0)]
        [Display(Name = "出席グループ管理番号")]
        public long attend_group_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "出席グループ番号")]
        public int group_id { get; set; }

        [Required]
        [Display(Name = "年齢管理番号")]
        public long age_id { get; set; }

        [Display(Name = "作成ユーザー")]
        public string create_user { get; set; }

        [Display(Name = "作成日時")]
        public string create_date { get; set; }

        [Display(Name = "更新ユーザー")]
        public string update_user { get; set; }

        [Display(Name = "更新日時")]
        public string update_date { get; set; }

        public virtual age_m age_m { get; set; }

    }
}