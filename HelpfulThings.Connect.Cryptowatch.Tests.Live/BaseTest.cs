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
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testconfig.json");

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDotNetConnectCryptowatch();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
