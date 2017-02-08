using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dobby.Extensions.Web.Mvc
{
    class DobbyControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return (IController) DobbyBootstrapper.GetContainer().ResolveNotRegisteredType(controllerType);
        }
    }
}
