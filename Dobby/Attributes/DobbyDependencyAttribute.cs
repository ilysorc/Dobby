using System;

namespace Dobby.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class DobbyDependencyAttribute : Attribute
    {
    }
}