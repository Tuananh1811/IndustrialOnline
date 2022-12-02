using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class NewsTranslationConfiguration : IEntityTypeConfiguration<NewsTranslation>
    {
        public void Configure(EntityTypeBuilder<NewsTranslation> builder)
        {
            builder.ToTable("NewsPostTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoDescription).HasMaxLength(500);

            builder.Property(x => x.SeoTitle).HasMaxLength(200);

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.NewsTable).WithMany(x => x.NewsTranslations).HasForeignKey(x => x.NewsTableId);

            builder.HasOne(x => x.Language).WithMany(x => x.NewsTranslations).HasForeignKey(x => x.LanguageId);

            

        }
    }
}
