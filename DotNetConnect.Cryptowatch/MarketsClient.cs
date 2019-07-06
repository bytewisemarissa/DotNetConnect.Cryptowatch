using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DotNetConnect.Cryptowatch.DataModel;
using DotNetConnect.Cryptowatch.Enums;

namespace DotNetConnect.Cryptowatch
{
    public interface IMarketsClient
    {
        Task<List<MarketSummary>> GetAllMarketsAsync();
        Task<Market> GetMarketDetailAsync(string exchange, string pair);
        Task<Price> GetPriceAsync(string exchange, string pair);
        Task<Summary> GetSummaryAsync(string exhcange, string pair);
        Task<List<Trade>> GetTradesAsync(string exchange, string pair, long since = 0,
            int limit = 0);

        Task<OrderBook> GetOrderBookAsync(string exhcange, string pair);

        Task<OhlcCollection> GetOhlcAsync(string exhcange, string pair, long after = 0, long before = 0,
            List<TimeBarLength> periods = null);
    }

    public class MarketsClient : IMarketsClient
    {
        private readonly IRequestRouter _router;

        public MarketsClient(IRequestRouter router)
        {
            _router = router;
        }

        public async Task<List<MarketSummary>> GetAllMarketsAsync()
        {
            return await _router.MakeRequest<List<MarketSummary>>(CryptowatchEndpoints.GetAllMarkets);
        }

        public async Task<Market> GetMarketDetailAsync(string exchange, string pair)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetMarketDetail, exchange, pair);
            return await _router.MakeRequest<Market>(formatedRoute);
        }

        public async Task<Price> GetPriceAsync(string exchange, string pair)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetPrice, exchange, pair);
            return await _router.MakeRequest<Price>(formatedRoute);
        }

        public async Task<Summary> GetSummaryAsync(string exhcange, string pair)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetSummary, exhcange, pair);
            return await _router.MakeRequest<Summary>(formatedRoute);
        }

        public async Task<List<Trade>> GetTradesAsync(string exchange, string pair, long since = 0,
            int limit = 0)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetTrades, exchange, pair);
            UriBuilder tradeUri = _router.GetUriBuilder();
            tradeUri.Path = formatedRoute;

            if (since > 0 && limit > 0)
            {
                tradeUri.Query = $"since={since}&limit={limit}";
            }
            else if (since > 0)
            {
                tradeUri.Query = $"since={since}";
            }
            else if (limit > 0)
            {
                tradeUri.Query = $"limit={limit}";
            }
            
            return await _router.MakeRequest<List<Trade>>(tradeUri.Path + tradeUri.Query);
        }

        public async Task<OrderBook> GetOrderBookAsync(string exhcange, string pair)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetOrderBook, exhcange, pair);
            return await _router.MakeRequest<OrderBook>(formatedRoute);
        }

        public async Task<OhlcCollection> GetOhlcAsync(string exhcange, string pair, long after = 0, long before = 0,
            List<TimeBarLength> periods = null)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetOhlc, exhcange, pair);
            UriBuilder ohlcUri = _router.GetUriBuilder();
            ohlcUri.Path = formatedRoute;


            Dictionary<string, string> queryStringParameters = new Dictionary<string, string>();

            if (after > 0 && before > 0)
            {
                throw new ApplicationException("Before or After can only be exclusivly set.");
            }

            if (after > 0)
            {
                queryStringParameters.Add("after", after.ToString());
            }

            if (before > 0)
            {
                queryStringParameters.Add("before", before.ToString());
            }

            if (periods != null && periods.Count > 0)
            {
                queryStringParameters.Add("periods", string.Join(",", periods.Select(p => p.LengthInSeconds).ToList()));
            }

            if (queryStringParameters.Count > 0)
            {
                string queryString = string.Join("&", queryStringParameters.Select(kv => kv.Key + '=' + kv.Value));
                ohlcUri.Query = queryString;
            }

            
            return await _router.MakeRequest<OhlcCollection>(ohlcUri.Path + ohlcUri.Query);
        }
    }
}
