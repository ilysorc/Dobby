using System;
using DobbyContainerConsoleSample.Interfaces;

namespace DobbyContainerConsoleSample.Contants
{
    class SmsSender : ISmsSender
    {
        private Guid _id;

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                this._id = Guid.NewGuid();
            }
        }

        public SmsSender()
        {
            Id = Guid.NewGuid();
        }

        public void Send()
        {
            Console.WriteLine("Sms sended. Id : " + Id);
        }
    }
}
