using EventStore.ClientAPI;
using PictureScan.Producer.Configurations;
using PictureScan.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureScan.Producer.Service
{
    public interface IPictureService
    {
        void Start();
        void Stop();
    }
    public class PictureService : IPictureService
    {
        IAppConfiguration _config;
        IBitmapService _bitmapService;
        IEventStoreConnection _connectionES;

        public PictureService(IAppConfiguration config, IBitmapService bitmapservice)
        {
            _config = config;
            _bitmapService = bitmapservice;
        }

        public void Start()
        {
            Console.WriteLine("Service Start");
            CreateESConnection();


        }

        private void CreateESConnection()
        {
            _connectionES = EventStoreConnection.Create(new Uri(_config.ESConnection));
            _connectionES.ConnectAsync().Wait();
            Console.WriteLine("Connect with ES.");


        }

        public void Stop()
        {
            _connectionES.Close();
            Console.WriteLine("Stop");            
        }
    }
}
