using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
  public  class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.ToTable("AboutUss");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();



        }
    }
}
