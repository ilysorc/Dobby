using Dobby;
using Dobby.Extensions.Web;
using DobbyMvcSample.Services;
using System.Web.Mvc;

namespace DobbyMvcSample
{
    public class DobbyConfig
    {
        public static void Build()
        {
            var dobbyContainer = new DobbyContainer();

            DobbyBootstrapper.Initialize(dobbyContainer);

            DependencyResolver.SetResolver(new DobbyDependencyResolver());

            dobbyContainer.AddModule(new DobbyTypeRegistrationModule());

            //RegisterTypes();
        }

        //private static void RegisterTypes()
        //{
        //    var dobbyContainer = DobbyBootstrapper.GetContainer();

        //    dobbyContainer.Register<IMessageService, MailService>();
        //}
    }
}