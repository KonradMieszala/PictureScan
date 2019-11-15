using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PictureScan.Producer.Configurations
{
    public interface IAppConfiguration
    {
        string DBConnection { get; }
        string ESConnection { get; }
        string DirectoryLocation { get; }

    }
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfigurationRoot _config;

        public AppConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _config = builder.Build();
        }

        public string DBConnection => _config.GetConnectionString("DBConnection");

        public string ESConnection => _config.GetConnectionString("ESConnection");

        public string DirectoryLocation => _config.GetSection("DirectoryLocation").Value;
    }
}
