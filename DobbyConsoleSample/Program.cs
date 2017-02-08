using Dobby;
using Dobby.LifetimeManagers;
using DobbyContainerConsoleSample.Contants;
using DobbyContainerConsoleSample.Interfaces;
using System;

namespace DobbyContainerConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dobbyContainer = new DobbyContainer();

            dobbyContainer.Register<IMailSender, MailSender>(new SingletonLifetimeManager());
            dobbyContainer.Register<ISmsSender, SmsSender>();

            var smsSender = dobbyContainer.Resolve<ISmsSender>();
            var mailSender = dobbyContainer.Resolve<IMailSender>();
            var mailSenderSecondResolve = dobbyContainer.Resolve<IMailSender>();

            smsSender.Send();

            mailSender.Send();
            mailSenderSecondResolve.Send();

            var childContainer = dobbyContainer.CreateAndGetChildContainer();

            var thirdMailSender = childContainer.Resolve<IMailSender>();

            thirdMailSender.Send();

            childContainer.Dispose();

            var fourthMailSender = dobbyContainer.Resolve<IMailSender>();

            fourthMailSender.Send();

            Console.Read();
        }
    }
}
