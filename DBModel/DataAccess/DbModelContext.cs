using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.DataAccess
{
   public class DbModelContext:DbContext
    {
        public DbModelContext(DbContextOptions options):base(options)  {  }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<CultureType> CultureTypes { get; set; }
        public DbSet<Packaging> Packagings { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ControlorEmployeesRelation> ControlorEmployeesRelations { get; set; }
        public DbSet<BarCodeGenerator> BarCodeGenerators { get; set; }


        //public abstract class Party
        //{
        //    public Guid Id { get; set; }
        //}

        //public class Person : Party
        //{
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //}

        //public class Company : Party
        //{
        //    public string Name { get; set; }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControlorEmployeesRelation>()              
              .HasKey(p => new { p.UserID, p.EmployeeID });

            modelBuilder.Entity<BarCodeGenerator>()
            .HasKey(p => new { p.EmployeeID, p.PlotId,p.PackagingId,p.Rbr,p.CultureId,p.CultureTypeId,p.DateGenerated });
        }


        //modelBuilder.Entity<Party>()
        //    .Map<Person>(m => { m.Requires("Type").HasValue("P"); m.ToTable("PartiesTable");})
        //    .Map<Company>(m => { m.Requires("Type").HasValue("C"); m.ToTable("PartiesTable"); })
        //    .ToTable("PartiesTable");
    }
}
