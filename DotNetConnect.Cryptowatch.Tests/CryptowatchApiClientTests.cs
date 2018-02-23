using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConnect.Cryptowatch.Tests
{
    [TestClass]
    public class CryptowatchApiClientTests : BaseTest
    {
        [TestMethod]
        public void CryptowatchApiClient_CheckCurrenBalanceAsync()
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
