using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class ProjectImageConfiguration:IEntityTypeConfiguration<ProjectImage>
    {
        public void Configure(EntityTypeBuilder<ProjectImage> builder)
        {
            builder.ToTable("ProjectImages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);

            builder.HasOne(x => x.Project).WithMany(x => x.ProjectImages).HasForeignKey(x => x.ProjectId);
            builder.HasOne(x => x.News).WithMany(x => x.NewsImages).HasForeignKey(x => x.ProjectId);
            builder.HasOne(x => x.AboutUs).WithMany(x => x.AboutImages).HasForeignKey(x => x.ProjectId);
        }

       
    }
}
