using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConnect.Cryptowatch.Test.Live
{
    [TestClass]
    public class Live_AggregateClientTests : BaseTest
    {
        [TestMethod]
        public void Live_Aggregate_GetPriceAggregateAsync()
        {
            var getPriceAggregateTask = TestApiClient.Aggregates.GetPriceAggregateAsync();
            getPriceAggregateTask.Wait();

            var result = getPriceAggregateTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void Live_Aggregate_GetMarketSummaryAggregateAsync()
        {
            var summaryAggregateAsync = TestApiClient.Aggregates.GetSummaryAggregateAsync();
            summaryAggregateAsync.Wait();

            var result = summaryAggregateAsync.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
