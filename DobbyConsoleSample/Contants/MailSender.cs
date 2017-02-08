using System;
using DobbyContainerConsoleSample.Interfaces;

namespace DobbyContainerConsoleSample.Contants
{
    class MailSender : IMailSender
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

        public MailSender()
        {
            Id = Guid.NewGuid();
        }

        public void Send()
        {
            Console.WriteLine("Mail sended. Id : " + Id);
        }
    }
}
