using ArhamTechnosoftLoyalty.Models.EntityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.DAL.Data
{
    public class ArhamTechLoyaltyDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArhamTechLoyaltyDbContext(DbContextOptions<ArhamTechLoyaltyDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Customize model
            //builder.Entity<User>(entity =>
            //{
            //    entity.HasIndex(e => e.Email).IsUnique();
            //});
            base.OnModelCreating(builder);
        }

        public DbSet<CompanyMaster> CompanyMaster { get; set; }
        public DbSet<CompanyBranch> CompanyBranch { get; set; }
        public DbSet<CompanyStore> CompanyStore { get; set; }
        public DbSet<CompanyUser> CompanyUser { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
    }
}
