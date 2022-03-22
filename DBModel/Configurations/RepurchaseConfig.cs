using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
   public class RepurchaseConfig : IEntityTypeConfiguration<Repurchase>
    {
        public void Configure(EntityTypeBuilder<Repurchase> builder)
        {
            builder.ToTable("Repurchases");
            builder.HasKey(x => x.Id);
        }
    }
}
