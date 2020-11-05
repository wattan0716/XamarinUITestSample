using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.UITest.Core.Utils
{
    public static class CommonUtil
    {
        public static T GetAppConfigValue<T>(string key, T defaultValue)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return value != null ? (T)converter.ConvertFrom(value) : defaultValue;
        }
    }
}
