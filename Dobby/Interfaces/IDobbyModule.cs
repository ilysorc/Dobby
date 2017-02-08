using System;

namespace Dobby.Interfaces
{
    public interface IDobbyModule : IDisposable
    {
        void Execute(DobbyContainer dobbyContainer);
    }
}