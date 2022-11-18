using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CNCIndustrial.Data.EF
{
   public class CncIndustrialDbContextFactory: IDesignTimeDbContextFactory<CncIndustrialDbContext>
    {
        public CncIndustrialDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CncIndustrialDb");

            var optionsBuilder = new DbContextOptionsBuilder<CncIndustrialDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CncIndustrialDbContext(optionsBuilder.Options);
        }
    }
}
