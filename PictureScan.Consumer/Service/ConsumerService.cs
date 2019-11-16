using EventStore.ClientAPI;
using Newtonsoft.Json;
using PictureScan.Consumer.Configurations;
using PictureScan.Models;
using PictureScan.Models.ComonModels;
using PictureScan.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScan.Consumer.Service
{
    public interface IConsumerService
    {
        void Start();
    }
    class ConsumerService : IConsumerService
    {
        readonly IAppConfiguration _config;
        IEventStoreConnection _connectionES;
        public Dictionary<string, int> directoryList = new Dictionary<string, int>(); 
        public ConsumerService(IAppConfiguration config)
        {
            _config = config;
        }
        public void Start()
        {
            Console.WriteLine("Start service");
            CreateESConnection();
            PrepareDictionary();

            _connectionES.ConnectToPersistentSubscription(
                "picture_stream", 
                "PictureScan", 
                (_, x) => DoSomething(_, x),
                (sub, reason, ex) => { },
                _connectionES.Settings.DefaultUserCredentials);

        }

        private void DoSomething(EventStorePersistentSubscriptionBase _, ResolvedEvent x)
        {

            var data = Encoding.ASCII.GetString(x.Event.Data);
            try
            {
                Console.WriteLine(data);
                var pictureInfo = JsonConvert.DeserializeObject<PictureInfo>(data);
                AddToDB(pictureInfo);

                _.Acknowledge(x);
            }catch(Exception ex)
            {
                Console.Write(ex);
                _.Fail(x, PersistentSubscriptionNakEventAction.Park, ex.Message);
            }
        }

        private void AddToDB(PictureInfo pictureInfo)
        {
            using (var db = new PSContext(_config.DBConnection))
            {
                var checkDirectoryIsOnList = directoryList.TryGetValue(pictureInfo.Path, out int directoryId);
                if (!checkDirectoryIsOnList) {                    
                    directoryId = AddDirectoryToDB(pictureInfo.Path, db);
                }
                AddPictureToDB(pictureInfo, directoryId, db);
            };
        }

        private void AddPictureToDB(PictureInfo p, int directoryId, PSContext db)
        {
            Picture picture = new Picture() { 
                DirectoryId = directoryId,
                CenterBottom = p.CenterBottom,
                CenterCenter = p.CenterCenter,
                CenterTop = p.CenterTop,
                LeftBottom = p.LeftBottom,
                LeftCenter = p.LeftCenter,
                LeftTop = p.LeftTop,
                RightBottom = p.RightBottom,
                RightCenter = p.RightCenter,
                RightTop = p.RightTop,
                FileName = p.FileName,
                CreationFileDate = p.CreationFileDate,
            };

            db.Picture.Add(picture);
            db.SaveChanges();
        }

        private int AddDirectoryToDB(string path, PSContext db)
        {
            Directory directory = new Directory() { FileDirectory = path };
            db.Directory.Add(directory);
            db.SaveChanges();
            directoryList.Add(directory.FileDirectory, directory.Id);
            return directory.Id;
        }

        private void PrepareDictionary()
        {
            using (var db = new PSContext(_config.DBConnection))
            {
                db.Directory.ToList().ForEach(x => directoryList.Add(x.FileDirectory, x.Id));
            }
        }

        private void CreateESConnection()
        {
            _connectionES = EventStoreConnection.Create(new Uri(_config.ESConnection));
            _connectionES.ConnectAsync().Wait();
            Console.WriteLine("Connect with ES.");
        }
    }
}
