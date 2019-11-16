using Microsoft.Extensions.DependencyInjection;
using PictureScan.Consumer.Configurations;
using PictureScan.Consumer.Service;
using System;

namespace PictureScan.Consumer
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IAppConfiguration, AppConfiguration>()
            .AddSingleton<IConsumerService, ConsumerService>()
            .BuildServiceProvider();

            var bar = serviceProvider.GetService<IConsumerService>();
            bar.Start();
        }
    }
}
