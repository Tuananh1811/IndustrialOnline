using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class NewsConfiguration : IEntityTypeConfiguration<NewsTable>
    {
        public void Configure(EntityTypeBuilder<NewsTable> builder)
        {
            builder.ToTable("NewsPostIndustrials");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.HinhAnhMinhHoa).HasMaxLength(200).IsRequired(true);


        }
    }
}
