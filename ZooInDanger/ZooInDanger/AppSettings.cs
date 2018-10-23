using System;
using System.Configuration;

namespace Epam.NetMentoring.Zoo
{
    public static class AppSettings
    {
        public static bool IsLoggingEnabled
        {
            get { return String.Equals(ConfigurationSettings.AppSettings["isLoggingEnabled"], "true"); }
        } 
    }
}