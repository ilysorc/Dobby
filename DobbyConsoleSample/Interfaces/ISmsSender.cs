using System;

namespace DobbyContainerConsoleSample.Interfaces
{
    interface ISmsSender
    {
        Guid Id { get; set; }
        void Send();
    }
}
