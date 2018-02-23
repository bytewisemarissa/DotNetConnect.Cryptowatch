using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetConnect.Cryptowatch.DataModel;

namespace DotNetConnect.Cryptowatch
{
    public interface IAggregatesClient
    {
        Task<Dictionary<string, Dictionary<string, decimal>>> GetPriceAggregateAsync();
        Task<Dictionary<string, Dictionary<string, Summary>>> GetSummaryAggregateAsync();
    }

    public class AggregatesClient : IAggregatesClient
    {
        private readonly IRequestRouter _router;

        public AggregatesClient(IRequestRouter router)
        {
            _router = router;
        }

        public async Task<Dictionary<string, Dictionary<string, decimal>>> GetPriceAggregateAsync()
        {
            var priceSlugs = await _router.MakeRequest<PriceSlugs>(CryptowatchEndpoints.AggregatePrices);

            var returnValue = new Dictionary<string, Dictionary<string, decimal>>();

            foreach (var priceSlug in priceSlugs)
            {
                var slugParts = priceSlug.Key.Split(':');

                if (!returnValue.Keys.Contains(slugParts[0]))
                {
                    returnValue.Add(slugParts[0], new Dictionary<string, decimal>());
                }

                returnValue[slugParts[0]].Add(slugParts[1], priceSlug.Value);
            }

            return returnValue;
        }

        public async Task<Dictionary<string, Dictionary<string, Summary>>> GetSummaryAggregateAsync()
        {
            var marketSummarySlugs = await _router.MakeRequest<SummarySlugs>(CryptowatchEndpoints.AggregateSummaries);

            var returnValue = new Dictionary<string, Dictionary<string, Summary>>();

            foreach (var marketSummarySlug in marketSummarySlugs)
            {
                var slugParts = marketSummarySlug.Key.Split(':');

                if (!returnValue.Keys.Contains(slugParts[0]))
                {
                    returnValue.Add(slugParts[0], new Dictionary<string, Summary>());
                }

                returnValue[slugParts[0]].Add(slugParts[1], marketSummarySlug.Value);
            }

            return returnValue;
        }
    }
}
