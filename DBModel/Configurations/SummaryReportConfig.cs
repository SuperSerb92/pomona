using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
   public class SummaryReportConfig : IEntityTypeConfiguration<SummaryReport>
    {

        public void Configure(EntityTypeBuilder<SummaryReport> builder)
        {
            builder.ToTable("SummaryReports");
            builder.HasKey(x => x.Id);
        }
    }
}
