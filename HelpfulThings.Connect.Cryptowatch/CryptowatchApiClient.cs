using System.Threading.Tasks;
using HelpfulThings.Connect.Cryptowatch.DataModel;
using HelpfulThings.Connect.Cryptowatch.Metering;

namespace HelpfulThings.Connect.Cryptowatch
{
    public interface ICryptowatchApiClient
    {
        IRequestMeteringMonitor RequestMeteringMonitor { get; }
        IAssetsClient Assets { get; }
        IPairsClient Pairs { get; }
        IExchangesClient Exchanges { get; }
        IMarketsClient Markets { get; }
        IAggregatesClient Aggregates { get; }
        Task<CryptowatchSystemInfo> CheckCurrentBalanceAsync();
    }

    public class CryptowatchApiClient : ICryptowatchApiClient
    {
        private readonly IRequestRouter _router;

        public IRequestMeteringMonitor RequestMeteringMonitor => _router.RequestMeteringMonitor;
        public IAssetsClient Assets { get; }
        public IPairsClient Pairs { get; }
        public IExchangesClient Exchanges { get; }
        public IMarketsClient Markets { get; }
        public IAggregatesClient Aggregates { get; }

        public CryptowatchApiClient(
            IRequestRouter router, 
            IAssetsClient assetsClient, 
            IPairsClient pairsClient,
            IExchangesClient exchangesClient,
            IMarketsClient marketsClient,
            IAggregatesClient aggregatesClient)
        {
            _router = router;
            Assets = assetsClient;
            Pairs = pairsClient;
            Exchanges = exchangesClient;
            Markets = marketsClient;
            Aggregates = aggregatesClient;
        }

        public async Task<CryptowatchSystemInfo> CheckCurrentBalanceAsync()
        {
            return await _router.MakeRequest<CryptowatchSystemInfo>(CryptowatchEndpoints.CheckBalance);
        }
        
    }
}
