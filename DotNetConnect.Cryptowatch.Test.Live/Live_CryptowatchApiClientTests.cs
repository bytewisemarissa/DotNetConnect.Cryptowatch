using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConnect.Cryptowatch.Test.Live
{
    [TestClass]
    public class Live_CryptowatchApiClientTests : BaseTest
    {
        [TestMethod]
        public void Live_CryptowatchApiClient_CheckCurrenBalanceAsync()
        {
            var checkCurrentBalanceTask = TestApiClient.CheckCurrentBalanceAsync();
            checkCurrentBalanceTask.Wait();

            var result = checkCurrentBalanceTask.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.DocumentationUrl);
            Assert.IsNotNull(result.Indexes);
            Assert.IsNotNull(result.Revision);
            Assert.IsNotNull(result.UpTime);
            Assert.AreNotEqual(0, result.Indexes.Count);
        }
    }
}
