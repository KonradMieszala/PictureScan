using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PictureScan.Models;
using System.IO;

namespace PictureScan.DBMigrator
{
    public class PSContextFactory : IDesignTimeDbContextFactory<PSContext>
    {
        public PSContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var section = configuration.GetSection("connectionstrings");
            var connectionString = section["dbConnection"];

            return new PSContext(connectionString);
        }
    }
}
