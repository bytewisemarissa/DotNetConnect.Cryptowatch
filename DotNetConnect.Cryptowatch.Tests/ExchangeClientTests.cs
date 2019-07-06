using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConnect.Cryptowatch.Tests
{
    [TestClass]
    public class ExchangeClientTests : BaseTest
    {
        [TestMethod]
        public void Exchanges_GetAllExchangesAsync()
        {
            var getAllExchangesTask = TestApiClient.Exchanges.GetAllExchangesAsync();
            getAllExchangesTask.Wait();

            var result = getAllExchangesTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void Exchanges_GetExchangeBySymbolAsync()
        {
            var getExchangeBySymbolTask = TestApiClient.Exchanges.GetExchangeBySymbolAsync("kraken");
            getExchangeBySymbolTask.Wait();

            var result = getExchangeBySymbolTask.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Symbol);
            Assert.IsNotNull(result.Active);
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.ExchangeRoutes);
            Assert.IsNotNull(result.ExchangeRoutes.Markets);
        }
    }
}
