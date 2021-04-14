//using DataAccessLayer.EF.Configurations;
using DBModel.Configurations;
using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel
{
   public class DbModelContext:DbContext
    {
        public DbModelContext(DbContextOptions options):base(options)  {  }
        public virtual DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<CultureType> CultureTypes { get; set; }
        public DbSet<Packaging> Packagings { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ControlorEmployeesRelation> ControlorEmployeesRelations { get; set; }
        public DbSet<BarCodeGenerator> BarCodeGenerators { get; set; }
        public DbSet<PlotList> PlotList { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControlorEmployeesRelation>()              
              .HasKey(p => new { p.UserID, p.EmployeeID });

            modelBuilder.Entity<BarCodeGenerator>()
            .HasKey(p => new { p.EmployeeID, p.PlotId,p.PackagingId,p.Rbr,p.CultureId,p.CultureTypeId,p.DateGenerated });
                                
             modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new LoginConfig());
            modelBuilder.ApplyConfiguration(new CultureTypeConfig());
            modelBuilder.ApplyConfiguration(new CultureConfig());
            modelBuilder.ApplyConfiguration(new PlotConfig());
            modelBuilder.ApplyConfiguration(new PlotListConfig());
        }

    }
}
