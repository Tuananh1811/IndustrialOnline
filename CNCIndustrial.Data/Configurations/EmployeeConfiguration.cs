using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeUser>
    {
        public void Configure(EntityTypeBuilder<EmployeeUser> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.ImagePath).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);

        }
    }
}

