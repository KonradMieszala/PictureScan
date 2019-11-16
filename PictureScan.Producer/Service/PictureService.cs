using EventStore.ClientAPI;
using PictureScan.Producer.Configurations;
using PictureScan.Service.Services;
using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        int countSendedPictureInfo = 0;
        DateTime startService = new DateTime();

        public PictureService(IAppConfiguration config, IBitmapService bitmapservice)
        {
            _config = config;
            _bitmapService = bitmapservice;
        }

        public async void Start()
        {
            Console.WriteLine("Service Start");
            CreateESConnection();
            startService = DateTime.Now;
            BrowsePhotos(_config.DirectoryLocation);
            Console.WriteLine($"Koniec.");
            Console.WriteLine($"Czas działania aplikacji {DateTime.Now - startService}.");
        }

        private void BrowsePhotos(string directoryLocation)
        {
            DirectoryInfo d = new DirectoryInfo(directoryLocation);
            var directoryList = d.GetDirectories();
            foreach(var directory in directoryList)
            {
                BrowsePhotos(directory.FullName);
            }

            FileInfo[] Files = d.GetFiles("*.*").Where(x => x.Extension.ToLower() == ".jpg" || x.Extension.ToLower() == ".png").ToArray();
            foreach (FileInfo file in Files)
            {
                var picture = _bitmapService.GetPicture(file.FullName);
                picture.CreationFileDate = file.CreationTime;

                SendToES(Newtonsoft.Json.JsonConvert.SerializeObject(picture));
            }
            Console.WriteLine($"Przeskanowano {countSendedPictureInfo} zdjęć.");
        }

        private void SendToES(string json)
        {
            var eventData = new EventData(Guid.NewGuid(), "picture", true, Encoding.UTF8.GetBytes(json), null);
            var send = _connectionES.AppendToStreamAsync("picture_stream", ExpectedVersion.Any, eventData);
            send.Wait();
            countSendedPictureInfo++;
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
