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
        public virtual DbSet<students_m> students_m { get; set; }
        public virtual DbSet<teachers_m> teachers_m { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<schools_m>()
                .HasMany(e => e.students_m)
                .WithOptional(e => e.schools_m)
                .HasForeignKey(e => e.enter_school);

            modelBuilder.Entity<schools_m>()
                .HasMany(e => e.students_m1)
                .WithOptional(e => e.schools_m1)
                .HasForeignKey(e => e.hope_school);

            modelBuilder.Entity<schools_m>()
                .HasMany(e => e.students_m2)
                .WithRequired(e => e.schools_m2)
                .HasForeignKey(e => e.school_id)
                .WillCascadeOnDelete(false);
        }
    }
}
