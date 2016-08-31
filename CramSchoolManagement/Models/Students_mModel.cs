namespace CramSchoolManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    //using CramSchoolManagement.Areas.Students.Models;

    public partial class Students_mModel : DbContext
    {
        public Students_mModel()
            : base("name=CsmModels")
        {
        }

        public virtual DbSet<students_m> students_m { get; set; }

        public virtual DbSet<students_face> students_face { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<students_m>()
                .HasMany(e => e.students_attendance)
                .WithRequired(e => e.students_m)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<students_m>()
                .HasMany(e => e.students_grade)
                .WithRequired(e => e.students_m)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<students_m>()
                .HasMany(e => e.students_guide)
                .WithRequired(e => e.students_m)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<students_m>()
                .HasMany(e => e.students_like_dislike)
                .WithRequired(e => e.students_m)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<CramSchoolManagement.Areas.Settings.Models.teachers_m> teachers_m { get; set; }
    }
}
