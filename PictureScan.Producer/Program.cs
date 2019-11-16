using System;
using Unity;
using PictureScan.Producer.Configurations;
using PictureScan.Producer.Service;
using System.Threading;

namespace PictureScan.Producer
{
    class Program
    {
        private static ManualResetEvent _exit;
        static void Main()
        {
            using (var container = new UnityContainer())
            {
                UnityBootstrapper.Register(container);
                var service = container.Resolve<IPictureService>();

                Action start = new Action(service.Start);
                Action stop = new Action(service.Stop);
                _exit = new ManualResetEvent(false);
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    Console.WriteLine("Cancelling service...");
                    stop?.Invoke();
                    _exit.Set();
                    _exit.Close();
                };
                start.Invoke();
                Console.WriteLine("Press CTRL+C to stop");
                _exit.WaitOne();
                _exit.Close();
            }
        }
    }
}
