using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace DBModel.Configurations
{
    public class PlotConfig : IEntityTypeConfiguration<Plot>
    {
        public void Configure(EntityTypeBuilder<Plot> builder)
        {
            builder.ToTable("Plots");
            builder.HasKey(x => x.PlotId);
            builder.HasOne(s => s.PlotList).WithMany().OnDelete(DeleteBehavior.NoAction);

        }
    }
}
