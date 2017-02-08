using System;
using Dobby.Interfaces;

namespace Dobby.LifetimeManagers
{
    public class PerResolveLifetimeManager : ILifetimeManager
    {
        private static string _key;

        public PerResolveLifetimeManager()
        {
            _key = Guid.NewGuid().ToString();
        } 

        public string GetKey()
        {
            return _key;
        }

        public void Dispose()
        {
            _key = null;
            GC.SuppressFinalize(this);
        }
    }
}