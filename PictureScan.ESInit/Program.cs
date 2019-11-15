using Microsoft.Extensions.DependencyInjection;
using PictureScan.ESInit.Configurations;
using PictureScan.ESInit.Service;
using System;

namespace PictureScan.ESInit
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppConfiguration, AppConfiguration>()
                .AddSingleton<IEventStoreService, EventStoreService>()
                .BuildServiceProvider();

            var bar = serviceProvider.GetService<IEventStoreService>();
            bar.Start();
        }
    }
}
