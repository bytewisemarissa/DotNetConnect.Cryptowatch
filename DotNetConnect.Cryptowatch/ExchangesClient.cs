using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetConnect.Cryptowatch.DataModel;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch
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
            return await _router.MakeRequest<List<ExchangeSummary>>(CryptowatchEndpoints.GetAllExchanges);
        }

        public async Task<Exchange> GetExchangeBySymbolAsync(string symbol)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetExchange, symbol);
            return await _router.MakeRequest<Exchange>(formatedRoute);
        }
    }
}
