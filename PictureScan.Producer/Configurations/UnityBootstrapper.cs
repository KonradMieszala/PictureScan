using PictureScan.Producer.Service;
using PictureScan.Service.Services;
using Unity;
using Unity.Lifetime;

namespace PictureScan.Producer.Configurations
{
    public class UnityBootstrapper
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IAppConfiguration, AppConfiguration>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBitmapService, BitmapService>();
            container.RegisterType<IPictureService, PictureService>();
        }
    }
}
