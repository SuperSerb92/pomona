using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DBModel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBModel.Configurations
{
    public class BarCodeConfig : IEntityTypeConfiguration<BarCodeGenerator>
    {
        public void Configure(EntityTypeBuilder<BarCodeGenerator> builder)
        {
            builder.ToTable("BarCodeGenerators");
            builder.Property(x => x.Bruto).HasPrecision(18, 3);
            builder.Property(x => x.Neto).HasPrecision(18, 3);
            builder.Property(x => x.Tara).HasPrecision(18, 3);



        }
    }
}
