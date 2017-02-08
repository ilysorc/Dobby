using System;

namespace Dobby.Interfaces
{
    public interface ILifetimeManager : IDisposable
    {
        string GetKey();
    }
}