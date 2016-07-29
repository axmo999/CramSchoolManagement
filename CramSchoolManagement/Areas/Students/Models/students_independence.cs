namespace CramSchoolManagement.Areas.Students.Models
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
        public DateTime week { get; set; }

        [Display(Name = "素直と笑顔の大切さを知る")]
        public decimal question01 { get; set; }

        [Display(Name = "自分から挨拶が出来る")]
        public decimal question02 { get; set; }

        [Display(Name = "時間を守ることが出来る")]
        public decimal question03 { get; set; }

        [Display(Name = "心と身の回りの準備を整える")]
        public decimal question04 { get; set; }

        [Display(Name = "人の名前を憶えて呼ぶことが出来る")]
        public decimal question05 { get; set; }

        [Display(Name = "学生として相応しい服装である")]
        public decimal question06 { get; set; }

        [Display(Name = "忘れ物がない")]
        public decimal question07 { get; set; }

        [Display(Name = "周りに迷惑をかけない")]
        public decimal question08 { get; set; }

        [Display(Name = "整理整頓をすることができる")]
        public decimal question09 { get; set; }

        [Display(Name = "傾聴の大切さを知り、実践することが出来る")]
        public decimal question10 { get; set; }

        [Display(Name = "前向きなプラスワードを使うことが出来る")]
        public decimal question11 { get; set; }

        [Display(Name = "感謝の気持ちを表すことが出来る")]
        public decimal question12 { get; set; }

        [Display(Name = "正しい言葉遣いで大人と会話することが出来る")]
        public decimal question13 { get; set; }

        [Display(Name = "塾内・社会で必要な姿勢を意識し習慣化している")]
        public decimal question14 { get; set; }

        [Display(Name = "短期目標を設定し、計画的に取り組むことが出来る。また、中・長期的な目標を達成するために学習面、生活面の両方から正しい行いができる。")]
        public decimal question15 { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual CramSchoolManagement.Models.students_m students_m { get; set; }

        public virtual CramSchoolManagement.Areas.Settings.Models.teachers_m teachers_m { get; set; }

        [Display(Name = "平均値")]
        public decimal avr
        {
            get { return getsum(); }
        }

        private decimal getsum()
        {
            decimal sum = question01;
            sum += question02;
            sum += question03;
            sum += question04;
            sum += question05;
            sum += question06;
            sum += question07;
            sum += question08;
            sum += question09;
            sum += question10;
            sum += question11;
            sum += question12;
            sum += question13;
            sum += question14;
            sum += question15;
            decimal avr = Convert.ToDecimal(sum) / 15;
            return avr;
        }
    }
}