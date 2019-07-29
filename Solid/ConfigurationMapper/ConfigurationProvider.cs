using System;
using System.Reflection;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfigurationSource _sourceConfigurations;
    
        public ConfigurationProvider(IConfigurationSource configs)
        {
            _sourceConfigurations = configs ?? throw new ArgumentException(nameof(configs));
        }

        public T Get<T>() where T : new()
        {
            var retObject = Activator.CreateInstance<T>();

            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (!Convertible(property))
                    continue;
                if (property.ReflectedType == null)
                    continue;
                var fullClassName = property.ReflectedType.FullName;

                var value = _sourceConfigurations.GetValue(fullClassName, property.Name);

                if (value == null)
                    continue;
                try
                {
                    var typedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(retObject, typedValue);                  
                }
                catch (FormatException e)
                {
                    throw new ArgumentException($"Could't convert value {value} to type {property.PropertyType} due to incorrect format", e);
                }
                catch (InvalidCastException e)
                {
                    throw new ArgumentException($"Could't convert value to type {property.PropertyType}", e);
                }
            }

            return retObject;
        }

        private bool Convertible(PropertyInfo info)
        {
            return info.PropertyType.IsPrimitive
                   || info.PropertyType == typeof(string);
        }
    }
}