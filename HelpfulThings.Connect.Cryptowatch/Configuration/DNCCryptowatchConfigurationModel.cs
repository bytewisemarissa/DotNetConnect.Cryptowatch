using System.Reflection;
using System.Runtime.InteropServices;

namespace HelpfulThings.Connect.Cryptowatch.Configuration
{
    public class DNCCryptowatchConfigurationModel
    {
        
        public long RequestMeterMaximum { get; set; }
        public float StopThresholdPercentage { get; set; }
        public string UserAgent { get; set; }
        public string UserAgentVersion { get; set; }

        public DNCCryptowatchConfigurationModel()
        {
            RequestMeterMaximum = 8000000000;
            StopThresholdPercentage = 0.00001f;
            UserAgent = "HelpfulThings.Connect.Cryptowatch";
            UserAgentVersion = typeof(RuntimeEnvironment).GetTypeInfo().Assembly
                .GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        }
    }
}
