using System;
using System.Collections.Generic;
using System.Reflection;
using Epam.NetMentoring.ConfigurationMapper.Contracts;
using Epam.NetMentoring.ConfigurationMapper.Storage;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfigurationSourceManager _configManager;
    
        public ConfigurationProvider(IConfigurationSourceManager configManager)
        {
            _configManager = configManager;
        }

        public T Get<T>(IEnumerable<string> environmentNames, string pathToConfigsFolder, ConfigFileType configFileType) where T : new()
        {
            var retObject = Activator.CreateInstance<T>();
            var configSource = _configManager.GetConfigSource(environmentNames, pathToConfigsFolder, configFileType);
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (!Convertible(property))
                    continue;
                if (property.ReflectedType == null)
                    continue;
                var fullClassName = property.ReflectedType.FullName;

                var value = configSource.GetValue(fullClassName, property.Name);

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