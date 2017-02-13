using Dobby.Interfaces;
using System;
using Dobby;
using DobbyMvcSample.Services;
using Dobby.Extensions.Web;

namespace DobbyMvcSample
{
    public class DobbyTypeRegistrationModule : IDobbyModule
    {
        public void Execute(DobbyContainer dobbyContainer)
        {
            dobbyContainer.Register<IMessageService, MailService>(new PerRequestLifetimeManager());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}