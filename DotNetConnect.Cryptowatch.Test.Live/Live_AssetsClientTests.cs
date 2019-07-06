using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConnect.Cryptowatch.Test.Live
{
    [TestClass]
    public class Live_AssetsClientTests : BaseTest
    {
        [TestMethod]
        public void Live_Assets_GetAllAssetsAsync()
        {
            var getAllAssetsTask = TestApiClient.Assets.GetAllAssetsAsync();
            getAllAssetsTask.Wait();

            var result = getAllAssetsTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void Live_Assets_GetAssetBySymbolAsync()
        {
            var getAssetTask = TestApiClient.Assets.GetAssetBySymbolAsync("btc");
            getAssetTask.Wait();

            var result = getAssetTask.Result;
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Id);
            Assert.IsNotNull(result.IsFiatCurrency);
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.Symbol);
            Assert.IsNotNull(result.Markets.Base);
            Assert.IsNotNull(result.Markets.Quote);
            Assert.AreNotEqual(0, result.Markets.Base.Count);
            Assert.AreNotEqual(0, result.Markets.Quote.Count);
        }
    }
}
