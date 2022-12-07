using CNCIndustrial.Data.Entities;
using CNCIndustrial.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace CNCIndustrial.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "This is home page of CNCTechIndustrial" },
              new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of CNCTechIndustrial" },
              new AppConfig() { Key = "HomeDescription", Value = "This is description of CNCTechIndustrial" }
              );
            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
               new Language() { Id = "en", Name = "English", IsDefault = false },
               new Language() { Id = "ko-kr", Name = "Korea", IsDefault = false },
               new Language() { Id = "ja-jp", Name = "Japan", IsDefault = false },
               new Language() { Id = "zh-cn", Name = "China", IsDefault = false }
            //test

            );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 },
                  new Category()
                  {
                      Id = 3,
                      IsShowOnHome = true,
                      ParentId = null,
                      SortOrder = 3,
                      Status = Status.Active
                  },
                   new Category()
                   {
                       Id = 4,
                       IsShowOnHome = true,
                       ParentId = null,
                       SortOrder = 4,
                       Status = Status.Active
                   }

                 );
            modelBuilder.Entity<ProjectLocation>().HasData(
          new ProjectLocation()
          {
              Id = 1,
              DateCreated = DateTime.Now,
              OriginalPrice = 100000,
              Price = 200000,
              Stock = 0,
              ViewCount = 0,
              iframeMap = "Http://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3716.8211643267987!2d105.68034141461068!3d21.318081685842323!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3134e5dadc526c53%3A0xeb6c8f677c9262da!2zS2h1IGPDtG5nIG5naGnhu4dwIGLDoSB0aGnhu4duIDE!5e0!3m2!1svi!2s!4v1668825924376!5m2!"
          });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                //dich sang 5 tieng
                new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Vĩnh Phúc", LanguageId = "vi", SeoAlias = "Vinh-Phuc", SeoDescription = "Khu công nghiệp Vĩnh Phúc", SeoTitle = "Khu công nghiệp Vĩnh Phúc" },
                new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Vinh Phuc", LanguageId = "en", SeoAlias = "Vinh-Phuc", SeoDescription = "Vinh Phuc Industrial Park", SeoTitle = "Vinh Phuc Industrial Park" },
                new CategoryTranslation() { Id = 3, CategoryId = 1, Name = "Vinh Phuc", LanguageId = "ko-kr", SeoAlias = "Vinh-Phuc", SeoDescription = "빈푹산업단지", SeoTitle = "빈푹산업단지" },
                new CategoryTranslation() { Id = 4, CategoryId = 1, Name = "Vinh Phuc", LanguageId = "ja-jp", SeoAlias = "Vinh-Phuc", SeoDescription = "ビンフック工業団地", SeoTitle = "ビンフック工業団地" },
                new CategoryTranslation() { Id = 5, CategoryId = 1, Name = "Vinh Phuc", LanguageId = "zh-cn", SeoAlias = "永福", SeoDescription = "永福工業園", SeoTitle = "永福工業園" },
            //dich sang 5 thu tieng
                new CategoryTranslation() { Id = 6, CategoryId = 2, Name = "Bắc Ninh", LanguageId = "vi", SeoAlias = "Bac-Ninh", SeoDescription = "Khu công nghiệp Bắc Ninh", SeoTitle = "Khu công nghiệp Bắc Ninh" },
                new CategoryTranslation() { Id = 7, CategoryId = 2, Name = "Bac Ninh", LanguageId = "en", SeoAlias = "Bac-Ninh", SeoDescription = "Bac Ninh Industrial Park", SeoTitle = "Bac Ninh Industrial Park" },
                new CategoryTranslation() { Id = 8, CategoryId = 2, Name = "Bac Ninh", LanguageId = "ko-kr", SeoAlias = "Bac-Ninh", SeoDescription = "박닌 산업단지", SeoTitle = "박닌 산업단지" },
                new CategoryTranslation() { Id = 9, CategoryId = 2, Name = "Bac Ninh", LanguageId = "ja-jp", SeoAlias = "Bac-Ninh", SeoDescription = "バクニン工業団地", SeoTitle = "バクニン工業団地" },
                new CategoryTranslation() { Id = 10, CategoryId = 2, Name = "Bac Ninh", LanguageId = "zh-cn", SeoAlias = "Bac-Ninh", SeoDescription = "永福工業園", SeoTitle = "永福工業園" },
                //test
                new CategoryTranslation() { Id = 11, CategoryId = 3, Name = "Hà Nam", LanguageId = "vi", SeoAlias = "Ha-Nam", SeoDescription = "Khu công nghiệp Hà Nam", SeoTitle = "Khu công nghiệp Hà Nam" },
                new CategoryTranslation() { Id = 12, CategoryId = 3, Name = "Ha Nam", LanguageId = "en", SeoAlias = "Ha-Nam", SeoDescription = "Ha Nam Industrial Park", SeoTitle = "Ha Nam Industrial Park" },
                new CategoryTranslation() { Id = 13, CategoryId = 3, Name = "Ha Nam", LanguageId = "ko-kr", SeoAlias = "Ha-Nam", SeoDescription = "하남산업단지", SeoTitle = "하남산업단지" },
                new CategoryTranslation() { Id = 14, CategoryId = 3, Name = "Ha Nam", LanguageId = "ja-jp", SeoAlias = "Ha-Nam", SeoDescription = "ハナム工業団地", SeoTitle = "ハナム工業団地" },
                new CategoryTranslation() { Id = 15, CategoryId = 3, Name = "Ha Nam", LanguageId = "zh-cn", SeoAlias = "Ha-Nam", SeoDescription = "河南工業園區", SeoTitle = "河南工業園區" },

                 new CategoryTranslation() { Id = 16, CategoryId = 4, Name = "TP. Hồ Chí Minh", LanguageId = "vi", SeoAlias = "Tp-Ho-Chi-Minh", SeoDescription = "Khu công nghiệp thành phố Hồ Chí Minh", SeoTitle = "Khu công nghiệp thành phố Hồ Chí Minh" },
                 new CategoryTranslation() { Id = 17, CategoryId = 4, Name = "Ho Chi Minh City", LanguageId = "en", SeoAlias = "Ho-Chi-Minh-City", SeoDescription = "Ho Chi Minh City Industrial Park", SeoTitle = "Ho Chi Minh City Industrial Park" },
                 new CategoryTranslation() { Id = 18, CategoryId = 4, Name = "호치민시", LanguageId = "ko-kr", SeoAlias = "Ho-Chi-Minh-City", SeoDescription = "호치민시 산업단지", SeoTitle = "호치민시 산업단지" },
                 new CategoryTranslation() { Id = 19, CategoryId = 4, Name = "ホーチミン市", LanguageId = "ja-jp", SeoAlias = "Ho-Chi-Minh-City", SeoDescription = "ホーチミン市工業団地", SeoTitle = "ホーチミン市工業団地" },
                 new CategoryTranslation() { Id = 20, CategoryId = 4, Name = "胡志明市", LanguageId = "zh-cn", SeoAlias = "Ho-Chi-Minh-City", SeoDescription = "胡志明市工業園區", SeoTitle = "胡志明市工業園區" }


                //

                );
            // any guid
            var roleId = new Guid("583B332A-9D8B-4B9C-B502-1F48D02B9EC7");
            var adminId = new Guid("E23C9B99-51D5-4F0E-A15B-9B5D6B4C9507");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {

                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "tanhdo18@gmail.com",
                NormalizedEmail = "tanhdo18@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "anhdt@123"),
                SecurityStamp = string.Empty,
                FullName = "Tuan Anh",
                Dob = new DateTime(2000, 11, 18)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Image-1", Description = "Mô tả", SortOrder = 1, Url = "#", Image = "/img/banner/DJI_0766.jpg", Status = Status.Active },
              new Slide() { Id = 2, Name = "Image-2", Description = "Mô tả", SortOrder = 2, Url = "#", Image = "/img/banner/DJI_0774.jpg", Status = Status.Active },
              new Slide() { Id = 3, Name = "Image-3", Description = "Mô tả", SortOrder = 3, Url = "#", Image = "/img/banner/DJI_0777.jpg", Status = Status.Active }
              
              );

        }
    }
    
}
