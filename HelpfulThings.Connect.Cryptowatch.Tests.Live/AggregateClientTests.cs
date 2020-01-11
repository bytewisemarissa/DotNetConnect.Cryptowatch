using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelpfulThings.Connect.Cryptowatch.Tests.Live
{
    [TestClass]
    public class AggregateClientTests : BaseTest
    {
        [TestMethod]
        public void Aggregate_GetPriceAggregateAsync()
        {
            var getPriceAggregateTask = TestApiClient.Aggregates.GetPriceAggregateAsync();
            getPriceAggregateTask.Wait();

            var result = getPriceAggregateTask.Result;
        }

        [TestMethod]
        public void Aggregate_GetMarketSummaryAggregateAsync()
        {
            var summaryAggregateAsync = TestApiClient.Aggregates.GetSummaryAggregateAsync();
            summaryAggregateAsync.Wait();

            var result = summaryAggregateAsync.Result;
        }
    }
}
