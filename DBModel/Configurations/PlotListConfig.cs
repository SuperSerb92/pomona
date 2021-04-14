using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
    public class PlotListConfig : IEntityTypeConfiguration<PlotList>
    {
        public void Configure(EntityTypeBuilder<PlotList> builder)
        {
            builder.ToTable("PlotList");
            builder.HasKey(x => x.PlotListId);

        }
    }
}
