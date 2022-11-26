using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class AboutUsTranslationConfiguration : IEntityTypeConfiguration<AboutUsTranslation>
    {
        public void Configure(EntityTypeBuilder<AboutUsTranslation> builder)
        {
            builder.ToTable("AboutUsTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Intro).IsRequired();

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoDescription).HasMaxLength(500);

            builder.Property(x => x.SeoTitle).HasMaxLength(200);

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.Language).WithMany(x => x.AboutUsTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.AboutUs).WithMany(x => x.AboutUsTranslations).HasForeignKey(x => x.AboutUsId);
            builder.HasOne(x => x.Employees).WithMany(x => x.AboutUsTranslations).HasForeignKey(x => x.EmployeeId);
        }
    }
}
