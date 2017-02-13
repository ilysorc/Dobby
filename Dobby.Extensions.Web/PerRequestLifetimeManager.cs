using System;
using System.Web;
using Dobby.Interfaces;

namespace Dobby.Extensions.Web
{
    public class PerRequestLifetimeManager : ILifetimeManager
    {
        public string GetKey()
        {
            if (HttpContext.Current.Session == null)
            {
                return Guid.NewGuid().ToString();
            }
            else
            {
                return HttpContext.Current.Session.SessionID;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
