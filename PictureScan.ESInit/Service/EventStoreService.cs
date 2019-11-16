using EventStore.ClientAPI;
using PictureScan.ESInit.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureScan.ESInit.Service
{
    public interface IEventStoreService
    {
        void Start();
    }
    public class EventStoreService : IEventStoreService
    {
        readonly string streamName = "picture_stream";
        readonly IAppConfiguration _config;
        IEventStoreConnection _connectionES;
        public EventStoreService(IAppConfiguration config)
        {
            _config = config;
        }
        public void Start()
        {
            CreateESConnection();

            CreateStream();
        }

        private void CreateStream()
        {
            var settings = PersistentSubscriptionSettings.Create();
            _connectionES.CreatePersistentSubscriptionAsync(streamName, "PictureScan", settings, _connectionES.Settings.DefaultUserCredentials);
            SetPermisions();
        }

        public void SetPermisions()
        {
            string stream = String.Format(streamName);
            // metadane jakie mają być ustawione dla danego streama
            string metadata = @"{
  ""$acl"": {
	""$r"": ""userReader"",
    ""$w"": ""userWriter"",
    ""$d"": ""$admins"",
    ""$mr"": ""$admins"",
    ""$mw"": ""$admins""
  },
  ""$maxAge"": 7948800
}";

            byte[] metadatabytes = Encoding.ASCII.GetBytes(metadata);
            _connectionES.SetStreamMetadataAsync(stream, ExpectedVersion.Any, metadatabytes).Wait();
        }

        private void CreateESConnection()
        {
            _connectionES = EventStoreConnection.Create(new Uri(_config.ESConnection));
            _connectionES.ConnectAsync().Wait();
            Console.WriteLine("Connect with ES.");
        }
    }
}
