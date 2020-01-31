using System;
using System.IO;
using HelpfulThings.Connect.Cryptowatch.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelpfulThings.Connect.Cryptowatch.Tests.Live
{
    [TestClass]
    public class BaseTest
    {
        private static IServiceProvider _serviceProvider;
        protected ICryptowatchApiClient TestApiClient;

        [TestInitialize]
        public void TestInitialize()
        {
            TestApiClient = (ICryptowatchApiClient)_serviceProvider.GetService(typeof(ICryptowatchApiClient));
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDotNetConnectCryptowatch(opts =>
            {
                opts.RequestMeterMaximum = 8000000000;
                opts.StopThresholdPercentage = 0.00001f;
                opts.UserAgent = "HelpfulThings.Connect.Cryptowatch";
                opts.UserAgentVersion = "1.0.0";
            });

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
