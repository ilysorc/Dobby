using Dobby.Interfaces;
using System;

namespace Dobby.Models
{
    class DependencyModel
    {
        public Type From { get; set; }
        public Type To { get; set; }
        public Type LifetimeManager { get; set; }
        public string LifetimeManagerKey { get; set; }
        public object ResolvedType { get; set; }
    }
}