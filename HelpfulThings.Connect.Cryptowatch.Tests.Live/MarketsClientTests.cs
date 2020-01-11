using System;
using System.Collections.Generic;
using HelpfulThings.Connect.Cryptowatch.Enums;
using HelpfulThings.Connect.Cryptowatch.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelpfulThings.Connect.Cryptowatch.Tests.Live
{
    [TestClass]
    public class MarketsClientTests : BaseTest
    {
        [TestMethod]
        public void Markets_GetAllMarketsAsync()
        {
            var getAllMarketsTask = TestApiClient.Markets.GetAllMarketsAsync();
            getAllMarketsTask.Wait();

            var result = getAllMarketsTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void Markets_GetMarketDetailAsync()
        {
            var getMarketDetailTask =
                TestApiClient.Markets.GetMarketDetailAsync("kraken", "btcusd");
            getMarketDetailTask.Wait();

            var result = getMarketDetailTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result.Exchange);
            Assert.AreNotEqual(string.Empty, result.Pair);
            Assert.AreNotEqual(default(bool), result.Active);
            Assert.IsNotNull(result.Routes);
            Assert.AreNotEqual(string.Empty, result.Routes.Ohlc);
            Assert.AreNotEqual(string.Empty, result.Routes.OrderBook);
            Assert.AreNotEqual(string.Empty, result.Routes.Price);
            Assert.AreNotEqual(string.Empty, result.Routes.Summary);
            Assert.AreNotEqual(string.Empty, result.Routes.Trades);
        }

        [TestMethod]
        public void Markets_GetPriceAsync()
        {
            var getPriceTask = TestApiClient.Markets.GetPriceAsync("kraken", "btcusd");
            getPriceTask.Wait();

            var result = getPriceTask.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CurrentPrice);
            Assert.AreNotEqual(0, result.CurrentPrice);
        }

        [TestMethod]
        public void Markets_GetSummaryAsync()
        {
            var getSummaryTask = TestApiClient.Markets.GetSummaryAsync("kraken", "btcusd");
            getSummaryTask.Wait();

            var result = getSummaryTask.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Price);
            Assert.AreNotEqual(default(decimal), result.Price.High);
            Assert.AreNotEqual(default(decimal), result.Price.Last);
            Assert.AreNotEqual(default(decimal), result.Price.Low);
            Assert.AreNotEqual(default(decimal), result.Price.Change.Absolute);
            Assert.AreNotEqual(default(decimal), result.Price.Change.Percentage);
            Assert.AreNotEqual(default(decimal), result.Volume);
            Assert.AreNotEqual(default(decimal), result.VolumeQuote);
        }

        [TestMethod]
        public void Markets_GetTradesAsync()
        {
            var getTradesTask = TestApiClient.Markets.GetTradesAsync("kraken", "btcusd");
            getTradesTask.Wait();

            var result = getTradesTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
            Assert.AreNotEqual(default(long), result[0].TimestampTicks);
            Assert.AreNotEqual(default(decimal), result[0].Price);
            Assert.AreNotEqual(default(decimal), result[0].Amount);
        }

        [TestMethod]
        public void Markets_GetTradesAsync_Since()
        {
            var getTradesTask = TestApiClient.Markets.GetTradesAsync("kraken", "btcusd", DateTime.UtcNow.AddMinutes(-2).GetUnixTimeStamp(), 0);
            getTradesTask.Wait();

            var result = getTradesTask.Result;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
            Assert.AreNotEqual(default(long), result[0].TimestampTicks);
            Assert.AreNotEqual(default(decimal), result[0].Price);
            Assert.AreNotEqual(default(decimal), result[0].Amount);
        }

        [TestMethod]
        public void Markets_GetTradesAsync_Limit()
        {
            var getTradesTask = TestApiClient.Markets.GetTradesAsync("kraken", "btcusd", 0L, 10);
            getTradesTask.Wait();

            var result = getTradesTask.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count);
            Assert.AreNotEqual(default(long), result[0].TimestampTicks);
            Assert.AreNotEqual(default(decimal), result[0].Price);
            Assert.AreNotEqual(default(decimal), result[0].Amount);
        }

        [TestMethod]
        public void Markets_GetTradesAsync_Limit_Since()
        {
            var getTradesTask = TestApiClient.Markets.GetTradesAsync("kraken", "btcusd", DateTime.UtcNow.AddMinutes(-5).GetUnixTimeStamp(), 10);
            getTradesTask.Wait();

            var result = getTradesTask.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count);
            Assert.AreNotEqual(default(long), result[0].TimestampTicks);
            Assert.AreNotEqual(default(decimal), result[0].Price);
            Assert.AreNotEqual(default(decimal), result[0].Amount);
        }

        [TestMethod]
        public void Markets_GetOrderBookAsync()
        {
            var getOrderBookTask = TestApiClient.Markets.GetOrderBookAsync("kraken", "btcusd");
            getOrderBookTask.Wait();

            var result = getOrderBookTask.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Asks);
            Assert.IsNotNull(result.Bids);
            Assert.AreNotEqual(0, result.Asks.Count);
            Assert.AreNotEqual(0, result.Bids.Count);
            Assert.AreNotEqual(default(decimal), result.Bids[0].Price);
            Assert.AreNotEqual(default(decimal), result.Bids[0].Amount);
        }

        [TestMethod]
        public void Markets_GetOhlcAsync()
        {
            var getOrderBookTask = TestApiClient.Markets.GetOhlcAsync("kraken", "btcusd");
            getOrderBookTask.Wait();

            var result = getOrderBookTask.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(14, result.Keys.Count);
            Assert.AreEqual(14, result.Values.Count);

            foreach (var kvPair in result)
            {
                Assert.AreNotEqual(0, kvPair.Value.Count);
            }
        }

        [TestMethod]
        public void Markets_GetOhlcAsync_Periods()
        {
            var getOrderBookTask = TestApiClient.Markets.GetOhlcAsync("kraken", "btcusd", 0, 0,
                new List<TimeBarLength>()
                {
                    TimeBarLength.ThreeMinutes
                });
            getOrderBookTask.Wait();

            var result = getOrderBookTask.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Keys.Count);
            Assert.AreEqual(1, result.Values.Count);

            foreach (var kvPair in result)
            {
                Assert.AreNotEqual(0, kvPair.Value.Count);
            }
        }

        [TestMethod]
        public void Markets_GetOhlcAsync_Before()
        {
            long before = DateTime.UtcNow.AddHours(-0.5).GetUnixTimeStamp();

            var getOrderBookTask = TestApiClient.Markets.GetOhlcAsync(
                "kraken", 
                "btcusd", 
                0, 
                before);
            getOrderBookTask.Wait();

            var result = getOrderBookTask.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(14, result.Keys.Count);
            Assert.AreEqual(14, result.Values.Count);

            foreach (var kvPair in result)
            {
                Assert.AreNotEqual(0, kvPair.Value.Count);
                foreach (var timeBar in kvPair.Value)
                {
                    Assert.AreEqual(true, timeBar.CloseTimeUtc.GetUnixTimeStamp() <= before);
                }
            }
        }

        [TestMethod]
        public void Markets_GetOhlcAsync_After()
        {
            long after = DateTime.UtcNow.AddHours(-1).GetUnixTimeStamp();

            var getOrderBookTask = TestApiClient.Markets.GetOhlcAsync(
                "kraken",
                "btcusd",
                after);
            getOrderBookTask.Wait();

            var result = getOrderBookTask.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(14, result.Keys.Count);
            Assert.AreEqual(14, result.Values.Count);

            foreach (var kvPair in result)
            {
                Assert.AreNotEqual(0, kvPair.Value.Count);
                bool includesTimeSpecified = false;
                foreach (var timeBar in kvPair.Value)
                {
                    if (timeBar.CloseTimeUtc.GetUnixTimeStamp() >= after - kvPair.Key.LengthInSeconds)
                    {
                        includesTimeSpecified = true;
                    }
                }
                Assert.AreEqual(true, includesTimeSpecified);
            }
        }

        [TestMethod]
        public void Markets_GetOhlcAsync_BeforeAfter()
        {
            long after = DateTime.UtcNow.AddHours(-1).GetUnixTimeStamp();
            long before = DateTime.UtcNow.AddHours(-0.5).GetUnixTimeStamp();

            try
            {
                var getOrderBookTask = TestApiClient.Markets.GetOhlcAsync(
                    "kraken",
                    "btcusd",
                    after,
                    before);
                getOrderBookTask.Wait();
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
                return;
            }
            
            Assert.AreEqual(true, false);
        }
    }
}
