using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AntiCorruptionManagementSystem.Models
{
    public class ACMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public ACMSDbContext():base("ACMSDbContext")
        {
            Database.SetInitializer<ACMSDbContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Wing> Wing { get; set; }
        public DbSet<SubWing> SubWing { get; set; }
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