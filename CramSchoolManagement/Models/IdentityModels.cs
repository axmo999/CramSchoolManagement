using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CramSchoolManagement.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=CsmModels")
        {
        }

        public virtual DbSet<teachers_m> teachers_m { get; set; }
    }
}