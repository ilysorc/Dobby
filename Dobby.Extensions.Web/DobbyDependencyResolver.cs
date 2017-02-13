using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dobby.Extensions.Web
{
    public class DobbyDependencyResolver : IDependencyResolver
    {
        private readonly DobbyContainer _dobbyContainer;

        public DobbyDependencyResolver()
        {
            _dobbyContainer = DobbyBootstrapper.GetContainer();
        }

        public object GetService(Type serviceType)
        {
            if (!_dobbyContainer.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }

                return _dobbyContainer.ResolveNotRegisteredType(serviceType);
            }
            return _dobbyContainer.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!_dobbyContainer.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return new List<object>();
                }
            }
            return _dobbyContainer.ResolveAll(serviceType);
        }
    }
}