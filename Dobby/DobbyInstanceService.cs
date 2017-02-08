using System;
using System.Linq;
using System.Collections.Generic;
using Dobby.Attributes;

namespace Dobby
{
    static class DobbyInstanceService
    {
        public static object GetInstance(Type type)
        {
            var constructors = type.GetConstructors();

            if (constructors == null)
            {
                type = TypeRepository.Types.Single(p => p.From == type).To;
                return Activator.CreateInstance(type);
            }

            var args = new List<object>();

            var constructorWithDependencyAttribute = constructors.FirstOrDefault(p => p.CustomAttributes.Any(q => q.AttributeType == typeof(DobbyDependencyAttribute)));

            if (constructorWithDependencyAttribute != null)
            {
                var parameters = constructorWithDependencyAttribute.GetParameters();

                foreach (var parameter in parameters)
                {
                    args.Add(GetInstance(parameter.ParameterType));
                }

                return constructorWithDependencyAttribute.Invoke(args.ToArray());
            }
            else
            {
                foreach (var constructor in constructors)
                {
                    foreach (var parameter in constructor.GetParameters())
                    {
                        args.Add(GetInstance(parameter.ParameterType));
                    }
                    return constructor.Invoke(args.ToArray());
                }
            }

            type = TypeRepository.Types.Single(p => p.From == type).To;
            return Activator.CreateInstance(type);
        }
    }
}