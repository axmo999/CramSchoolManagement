namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students_m
    {
        [Key]
        [Display(Name = "ê∂ìkä«óùî‘çÜ")]
        public long students_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string last_name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string first_name { get; set; }

        [StringLength(2147483647)]
        public string middle_name { get; set; }

        public long school_id { get; set; }

        public long gender { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string birthday { get; set; }

        [MaxLength(2147483647)]
        public byte[] face { get; set; }

        public long? postal_code { get; set; }

        [StringLength(2147483647)]
        public string address { get; set; }

        public long? phone_number { get; set; }

        public long? hope_school { get; set; }

        public long? enter_school { get; set; }

        [StringLength(2147483647)]
        public string note { get; set; }

        public string create_user { get; set; }

        public string create_date { get; set; }

        public string update_user { get; set; }

        public string update_date { get; set; }

        public virtual schools_m schools_m { get; set; }

        public virtual schools_m schools_m1 { get; set; }

        public virtual schools_m schools_m2 { get; set; }
    }
}
