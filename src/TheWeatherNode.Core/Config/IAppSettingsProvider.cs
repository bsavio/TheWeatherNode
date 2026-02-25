using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherNode.Core.Config
{
    public interface IAppSettingsProvider
    {
        T GetAppSetting<T>();

        T GetAppSetting<T>(string appSetting);

        IConfigurationSection GetConfigSection(string appSetting);

        string GetEnvironment();
    }
}
