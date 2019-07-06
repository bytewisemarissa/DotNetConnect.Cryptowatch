using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using DotNetConnect.Cryptowatch.Metering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.Configuration
{
    public static class DotNetConnectCryptowatchConfigurationExtensions
    {
        public static void AddDotNetConnectCryptowatch(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var configurationJson = configuration["DotNetConnect.Cryptowatch"];

            var dncCryptowatchConfigurationModel = !string.IsNullOrEmpty(configurationJson)
                ? JsonConvert.DeserializeObject<DNCCryptowatchConfigurationModel>(configurationJson)
                : new DNCCryptowatchConfigurationModel();

            serviceCollection.AddSingleton<DNCCryptowatchConfigurationModel>(dncCryptowatchConfigurationModel);
            serviceCollection.AddTransient<ICryptowatchApiClient, CryptowatchApiClient>();
            serviceCollection.AddSingleton<IRequestMeteringMonitor, RequestMeteringMonitor>();
            serviceCollection.AddTransient<IRequestRouter, RequestRouter>();
            serviceCollection.AddTransient<IAssetsClient, AssetsClient>();
            serviceCollection.AddTransient<IPairsClient, PairsClient>();
            serviceCollection.AddTransient<IExchangesClient, ExchangesClient>();
            serviceCollection.AddTransient<IMarketsClient, MarketsClient>();
            serviceCollection.AddTransient<IAggregatesClient, AggregatesClient>();
        }
    }
}
