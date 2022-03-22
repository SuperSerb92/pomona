using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
  public  class ProfitLossReportConfig : IEntityTypeConfiguration<ProfitLossReport>
    {
        public void Configure(EntityTypeBuilder<ProfitLossReport> builder)
        {
            builder.ToTable("ProfitLossReports");
            builder.HasNoKey();
        }
    }
}
