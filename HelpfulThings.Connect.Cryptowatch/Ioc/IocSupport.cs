using System;
using HelpfulThings.Connect.Cryptowatch.Metering;
using Microsoft.Extensions.DependencyInjection;

namespace HelpfulThings.Connect.Cryptowatch.Ioc
{
    public static class IocSupport
    {
        public static void AddDotNetConnectCryptowatch(
            this IServiceCollection serviceCollection,
            Action<CryptowatchApiOptions> optionsAction = null)
        {
            var options = new CryptowatchApiOptions();
            optionsAction?.Invoke(options);
            
            serviceCollection.AddSingleton<CryptowatchApiOptions>(options);
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
