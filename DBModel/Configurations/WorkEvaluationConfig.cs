using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
  public  class WorkEvaluationConfig : IEntityTypeConfiguration<WorkEvaluation>
    {


        public void Configure(EntityTypeBuilder<WorkEvaluation> builder)
        {
            builder.ToTable("WorkEvaluations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Neto).HasPrecision(18, 3);


        }
    }
}
