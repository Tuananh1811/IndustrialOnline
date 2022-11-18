using CNCIndustrial.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.Configurations
{
   public class ProjectInCategoryConfiguration : IEntityTypeConfiguration<ProjectInCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectInCategory> builder)
        {
            builder.HasKey(t => new { t.CategoryId, t.ProjectId });

            builder.ToTable("ProjectInCategories");

            builder.HasOne(t => t.Project).WithMany(pc => pc.ProductInCategories)
                .HasForeignKey(pc => pc.ProjectId);

            builder.HasOne(t => t.Category).WithMany(pc => pc.ProjectInCategories)
              .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
