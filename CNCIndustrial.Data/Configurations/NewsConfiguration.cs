using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("Newss");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


          
        }
    }
}
