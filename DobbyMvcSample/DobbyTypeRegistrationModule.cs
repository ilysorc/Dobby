using Dobby.Interfaces;
using System;
using Dobby;
using DobbyMvcSample.Services;

namespace DobbyMvcSample
{
    public class DobbyTypeRegistrationModule : IDobbyModule
    {
        public void Execute(DobbyContainer dobbyContainer)
        {
            dobbyContainer.Register<IMessageService, MailService>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}