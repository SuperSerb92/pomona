using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
   public class SummaryRepurchaseConfig : IEntityTypeConfiguration<SummaryReportRepurchase>
    {

        public void Configure(EntityTypeBuilder<SummaryReportRepurchase> builder)
        {
            builder.ToTable("SummaryReportRepurchases");
            builder.HasKey(x => x.Id);
        }
    }
}
