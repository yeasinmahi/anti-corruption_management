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
        public ACMSDbContext():base("AntiCorruptionManagementSystem")
        {
            Database.SetInitializer<ACMSDbContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Wing> Wing { get; set; }
        public DbSet<Sajeka> Sajeka { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}