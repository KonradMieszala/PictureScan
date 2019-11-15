using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PictureScan.ESInit.Configurations
{
    public interface IAppConfiguration
    {
        string ESConnection { get; }
    }
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfigurationRoot _config;
        public AppConfiguration()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }

        public string ESConnection => _config.GetConnectionString("ESConnection");
    }
}
