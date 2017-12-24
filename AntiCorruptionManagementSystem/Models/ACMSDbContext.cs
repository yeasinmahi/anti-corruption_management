using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AntiCorruptionManagementSystem.Models
{
    public class AcmsDbContext : IdentityDbContext<ApplicationUser>
    {
        public AcmsDbContext():base("ACMSDbContext")
        {
            Database.SetInitializer<AcmsDbContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Wing> Wing { get; set; }
        public DbSet<Sajeka> Sajeka { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Case> Case { get; set; }
        public DbSet<CaseObjection> CaseObjection { get; set; }
        public DbSet<AccusedPersonInfo> AccusedPersonInfo { get; set; }
        public DbSet<Accuser> Accuser { get; set; }

        public DbSet<InvestigationWorkProgress> InvestigationWorkProgress { get; set; }
        public DbSet<InquiryWorkProgress> InquiryWorkProgress { get; set; }
    }
}