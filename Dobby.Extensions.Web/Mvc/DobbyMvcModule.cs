using Dobby.Interfaces;
using System;
using System.Web.Mvc;

namespace Dobby.Extensions.Web.Mvc
{
    public class DobbyMvcModule : IDobbyModule
    { 
        public void Execute(DobbyContainer dobbyContainer)
        {
            dobbyContainer.Register<IControllerActivator, DobbyControllerActivator>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}