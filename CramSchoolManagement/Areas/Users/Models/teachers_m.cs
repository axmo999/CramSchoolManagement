namespace CramSchoolManagement.Areas.Users.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class teachers_m
    {
        [Key]
        public long teachers_id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string teachers_password { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string last_name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string first_name { get; set; }

        [StringLength(2147483647)]
        public string middle_name { get; set; }

        public long gender { get; set; }

        [StringLength(2147483647)]
        public string note { get; set; }

        public long administrator_flag { get; set; }

        public long create_user { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string create_date { get; set; }

        public long? update_user { get; set; }

        [StringLength(2147483647)]
        public string update_date { get; set; }
    }
}
