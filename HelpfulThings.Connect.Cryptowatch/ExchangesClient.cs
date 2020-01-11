using System.Collections.Generic;
using System.Threading.Tasks;
using HelpfulThings.Connect.Cryptowatch.DataModel;

namespace HelpfulThings.Connect.Cryptowatch
{
    public interface IExchangesClient
    {
        Task<List<ExchangeSummary>> GetAllExchangesAsync();
        Task<Exchange> GetExchangeBySymbolAsync(string symbol);
    }

    public class ExchangesClient : IExchangesClient
    {
        private readonly IRequestRouter _router;

        public ExchangesClient(IRequestRouter router)
        {
            _router = router;
        }

        public async Task<List<ExchangeSummary>> GetAllExchangesAsync()
        {
            return await _router.MakeRequest<List<ExchangeSummary>>(CryptowatchEndpoints.AllExchanges);
        }

        public async Task<Exchange> GetExchangeBySymbolAsync(string symbol)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.Exchange, symbol);
            return await _router.MakeRequest<Exchange>(formatedRoute);
        }
    }
}
