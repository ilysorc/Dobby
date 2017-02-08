using System;
using Dobby.Interfaces;

namespace Dobby.LifetimeManagers
{
    public class SingletonLifetimeManager : ILifetimeManager
    {
        private static string _key;

        public SingletonLifetimeManager()
        {
            _key = "single";
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