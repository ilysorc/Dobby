using System;

namespace DobbyContainerConsoleSample.Interfaces
{
    interface IMailSender
    {
        Guid Id { get; set; }
        void Send();
    }
}
