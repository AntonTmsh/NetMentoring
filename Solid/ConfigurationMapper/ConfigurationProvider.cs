﻿using System;
using System.Collections;
using System.Reflection;
using Epam.NetMentoring.ConfigurationMapper.Contracts;

namespace Epam.NetMentoring.ConfigurationMapper
{
    public class ConfigurationProvider : IProvider
    {
        public ConfigurationProvider(IDictionary configs)
        {
            SourceConfigurations = configs;
        }
        private IDictionary SourceConfigurations { get; }
        public T Get<T>()
        {
            var retObject = Activator.CreateInstance<T>();

            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (!property.CanWrite || !Convertible(property))
                    continue;
                if (property.ReflectedType == null)
                    continue;
                var fullClassName = property.ReflectedType.FullName;
                var value = string.Empty;
                if (SourceConfigurations.Contains(fullClassName))
                {
                    var sourceConfiguration = (IDictionary) SourceConfigurations[fullClassName];
                    if (sourceConfiguration.Contains(property.Name))
                        value = (string) sourceConfiguration[property.Name];
                }

                if (value == null)
                    continue;
                try
                {
                    if (value == string.Empty)
                        property.SetValue(retObject, null, null);
                    else
                    {
                        var typedValue = Convert.ChangeType(value, property.PropertyType);
                        property.SetValue(retObject, typedValue);
                    }

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