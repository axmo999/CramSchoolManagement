namespace CramSchoolManagement.Areas.Settings.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MastersModel : DbContext
    {
        public MastersModel()
            : base("name=CsmModels")
        {
        }

        public virtual DbSet<classes_m> classes_m { get; set; }
        public virtual DbSet<divisions_m> divisions_m { get; set; }
        public virtual DbSet<exams_m> exams_m { get; set; }
        public virtual DbSet<gender_m> gender_m { get; set; }
        public virtual DbSet<schools_m> schools_m { get; set; }
        public virtual DbSet<offices_m> offices_m { get; set; }
        public virtual DbSet<teachers_m> teachers_m { get; set; }
        public virtual DbSet<age_m> age_m { get; set; }
        public virtual DbSet<atteds_m> atteds_m { get; set; }
        public virtual DbSet<average_scores_m> average_scores_m { get; set; }
        public virtual DbSet<attend_group_m> attend_group_m { get; set; }
    }
}
