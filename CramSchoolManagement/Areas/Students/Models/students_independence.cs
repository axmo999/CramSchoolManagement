﻿namespace CramSchoolManagement.Areas.Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class students_independence
    {
        [Key]
        [Display(Name = "自立管理番号")]
        public long independence_id { get; set; }

        [Display(Name = "生徒管理番号")]
        public string students_id { get; set; }

        [Display(Name = "講師管理ID")]
        public string Id { get; set; }

        [Display(Name = "投稿日")]
        [DataType(DataType.Date)]
        public string week { get; set; }

        [Display(Name = "素直と笑顔の大切さを知る")]
        public int question01 { get; set; }

        [Display(Name = "自分から挨拶が出来る")]
        public int question02 { get; set; }

        [Display(Name = "時間を守ることが出来る")]
        public int question03 { get; set; }

        [Display(Name = "心と身の回りの準備を整える")]
        public int question04 { get; set; }

        [Display(Name = "人の名前を憶えて呼ぶことが出来る")]
        public int question05 { get; set; }

        [Display(Name = "学生として相応しい服装である")]
        public int question06 { get; set; }

        [Display(Name = "忘れ物がない")]
        public int question07 { get; set; }

        [Display(Name = "周りに迷惑をかけない")]
        public int question08 { get; set; }

        [Display(Name = "整理整頓をすることができる")]
        public int question09 { get; set; }

        [Display(Name = "慶弔の大切さを知り、実践することが出来る")]
        public int question10 { get; set; }

        [Display(Name = "前向きなプラスワードを使うことが出来る")]
        public int question11 { get; set; }

        [Display(Name = "感謝の気持ちを表すことが出来る")]
        public int question12 { get; set; }

        [Display(Name = "正しい言葉遣いで大人と会話することが出来る")]
        public int question13 { get; set; }

        [Display(Name = "塾内・社会で必要な姿勢を意識し習慣化している")]
        public int question14 { get; set; }

        [Display(Name = "短期目標を設定し、計画的に取り組むことが出来る。\nまた、中・長期的な目標を達成するために学習面、生活面の両方から正しい行いができる。")]
        public int question15 { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.teachers_m teachers_m { get; set; }
    }
}