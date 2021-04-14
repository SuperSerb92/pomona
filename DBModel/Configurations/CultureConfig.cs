using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
   public class CultureConfig : IEntityTypeConfiguration<Culture>
    {


        public void Configure(EntityTypeBuilder<Culture> builder)
        {
            builder.ToTable("Cultures");
            builder.HasKey(x => x.CultureId);


          
        }
    }
}
