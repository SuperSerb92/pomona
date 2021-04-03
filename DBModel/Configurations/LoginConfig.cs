using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Configurations
{
  public  class LoginConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.UserID);
          //  builder.Property(x => x.UserName).HasMaxLength(50);
        }
    }
}
