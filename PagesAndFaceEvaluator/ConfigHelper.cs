using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagesAndFaceEvaluator
{
    public static class ConfigHelper
    {
        public enum ConfigKey
        {
            LastPath
        }

        public static string GetValue(string key)
        {
            if (Enum.GetNames(typeof(ConfigKey)).Contains(key))
                return ConfigurationManager.AppSettings[key];
            else
                return null;
        }

        public static bool ChangeValue(string key, string newValue)
        {
            if (Enum.GetNames(typeof(ConfigKey)).Contains(key))
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = newValue;
                configuration.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            else
                return false;
        }
    }
}
