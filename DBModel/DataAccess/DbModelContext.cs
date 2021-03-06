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
    }
}
