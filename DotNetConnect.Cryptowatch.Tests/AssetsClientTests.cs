using DotNetConnect.Cryptowatch.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConnect.Cryptowatch.Tests
{
    [TestClass]
    public class AssetsClientTests : BaseTest
    {
        [TestMethod]
        public void Assets_GetAllAssetsAsync()
        {
            var getAllAssetsTask = TestApiClient.Assets.GetAllAssetsAsync();
            getAllAssetsTask.Wait();

            var result = getAllAssetsTask.Result;
            
        }

        [TestMethod]
        public void Assets_GetAssetBySymbolAsync()
        {
            var getAssetTask = TestApiClient.Assets.GetAssetBySymbolAsync("btc");
            getAssetTask.Wait();

            var result = getAssetTask.Result;
            
        }
    }
}
