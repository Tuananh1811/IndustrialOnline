using CNCIndustrial.Data.Configurations;
using CNCIndustrial.Data.Entities;
using CNCIndustrial.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCIndustrial.Data.EF
{
   public class CncIndustrialDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {
        public CncIndustrialDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            //modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfigguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new AboutUsConfiguration());
            modelBuilder.ApplyConfiguration(new AboutUsTranslationConfiguration());
        
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectImageConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            ////Data seeding
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProjectLocation> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProjectInCategory> ProjectInCategories { get; set; }
        public DbSet<NewsTranslation> NewsTranslations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        
        public DbSet<News> Newss { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<ProjectTranslation> ProjectTranslations { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<AboutUsTranslation> AboutUsTranslations { get; set; }
      
       // public DbSet<AccessibilityTranslation> AccessibilityTranslations { get; set; }

    }
}
