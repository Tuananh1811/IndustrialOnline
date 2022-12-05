using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
  public  class ProjectTranslationConfiguration : IEntityTypeConfiguration<ProjectTranslation>
    {
        public void Configure(EntityTypeBuilder<ProjectTranslation> builder)
        {
            builder.ToTable("ProjectTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

         

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.Languages).WithMany(x => x.ProjectTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.Project).WithMany(x => x.ProjectTranslations).HasForeignKey(x => x.ProjectId);
           
           

        }
    }
}
