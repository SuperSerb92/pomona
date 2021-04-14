using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
  public  class CultureTypeConfig : IEntityTypeConfiguration<CultureType>
    {
     

        public void Configure(EntityTypeBuilder<CultureType> builder)
        {
    
            builder.ToTable("CultureTypes");
            builder.HasKey(x => x.CultureTypeId);
            builder.HasOne(s => s.Culture).WithMany().OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
