using System;
using System.Linq;
using System.Collections.Generic;
using Dobby.Interfaces;
using Dobby.Models;
using Dobby.LifetimeManagers;

namespace Dobby
{
    public class DobbyContainer
    {
        private List<DependencyModel> _registeredTypes;

        public DobbyContainer()
        {
            TypeRepository.Types = new List<DependencyModel>();
            _registeredTypes = TypeRepository.Types;
        }

        public void AddModule(IDobbyModule dobbyModule)
        {
            dobbyModule.Execute(this);
        }

        public DobbyContainer CreateAndGetChildContainer()
        {
            var childContainer = new DobbyContainer();
            childContainer._registeredTypes = _registeredTypes;

            return childContainer;
        }

        public void Register<I, C>(ILifetimeManager lifetimeManager = null) where C : I, new()
        {
            Register(typeof(I), typeof(C), lifetimeManager);
        }

        public void Register(Type i, Type c, ILifetimeManager lifetimeManager = null)
        {
            if (lifetimeManager == null)
                lifetimeManager = new PerResolveLifetimeManager();

            var dependencyModel = new DependencyModel
            {
                From = i,
                To = c,
                LifetimeManager = lifetimeManager.GetType(),
                LifetimeManagerKey = lifetimeManager.GetKey(),
                ResolvedType = DobbyInstanceService.GetInstance(c)
            };

            _registeredTypes.Add(dependencyModel);
            lifetimeManager.Dispose();
        }

        public I Resolve<I>()
        {
            return (I)Resolve(typeof(I));
        }

        public object Resolve(Type type)
        {
            if (IsRegistered(type))
            {
                var dependencyModel = _registeredTypes.Single(p => p.From == type);

                var lifetimeManager = DobbyInstanceService.GetInstance(dependencyModel.LifetimeManager) as ILifetimeManager;

                if (lifetimeManager.GetKey() == dependencyModel.LifetimeManagerKey)
                {
                    lifetimeManager.Dispose();
                    return dependencyModel.ResolvedType;
                }
                else
                {
                    _registeredTypes.Remove(dependencyModel);

                    dependencyModel.ResolvedType = DobbyInstanceService.GetInstance(dependencyModel.To);
                    dependencyModel.LifetimeManagerKey = lifetimeManager.GetKey();

                    lifetimeManager.Dispose();

                    _registeredTypes.Add(dependencyModel);

                    return dependencyModel.ResolvedType;
                }
            }
            else
            {
                throw new Exception($"{type} is not registered to DobbyContainer.");
            }
        }

        public object ResolveNotRegisteredType(Type type)
        {
            return DobbyInstanceService.GetInstance(type);
        }

        public IEnumerable<object> ResolveAll(Type type)
        {
            return (IEnumerable<object>)Resolve(type.MakeArrayType());
        }

        public bool IsRegistered(Type type)
        {
            return _registeredTypes.Any(p => p.From == type);
        }

        public void Dispose()
        {
            _registeredTypes = null;
            GC.SuppressFinalize(this);
        }
    }
}