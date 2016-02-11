using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConvertKitSharp.Tests
{
    public static class Utils
    {
        public static string ApiKey { get; } = ConfigurationManager.AppSettings.Get("ApiKey");
    }
}
