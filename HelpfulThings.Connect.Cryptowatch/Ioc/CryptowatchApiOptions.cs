namespace HelpfulThings.Connect.Cryptowatch.Ioc
{
    public class CryptowatchApiOptions
    {
        
        public long RequestMeterMaximum { get; set; }
        public float StopThresholdPercentage { get; set; }
        public string UserAgent { get; set; }
        public string UserAgentVersion { get; set; }

        public CryptowatchApiOptions()
        {
            RequestMeterMaximum = 8000000000;
            StopThresholdPercentage = 0.00001f;
            UserAgent = $"HelpfulThings-Connect-Cryptowatch";
            UserAgentVersion = GetType().Assembly.GetName().Version.ToString();
        }
    }
}
