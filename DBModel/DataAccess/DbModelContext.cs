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
    }
}
