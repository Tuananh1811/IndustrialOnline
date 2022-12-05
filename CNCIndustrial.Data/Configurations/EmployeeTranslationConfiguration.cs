using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class EmployeeTranslationConfiguration : IEntityTypeConfiguration<EmployeeTranslation>
    {
        public void Configure(EntityTypeBuilder<EmployeeTranslation> builder)
        {
            builder.ToTable("EmployeeTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Position).IsRequired().HasMaxLength(200);

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.Languages).WithMany(x => x.EmployeeTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.Employee).WithMany(x => x.EmployeeTranslations).HasForeignKey(x => x.EmployeeId);

        }
    }
}
