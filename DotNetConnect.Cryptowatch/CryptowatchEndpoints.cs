using System;
using System.Collections.Generic;
using System.Text;
using DotNetConnect.Cryptowatch.DataModel;

namespace DotNetConnect.Cryptowatch
{
    internal static class CryptowatchEndpoints
    {
        internal const string CheckBalance = "/";
        internal const string GetAllAssets = "assets";
        internal const string GetAsset = "assets/{0}";
        internal const string GetAllPairs = "pairs";
        internal const string GetPair = "pairs/{0}";
        internal const string GetAllExchanges = "exchanges";
        internal const string GetExchange = "exchanges/{0}";
        internal const string GetAllMarkets = "markets";
        internal const string GetMarketDetail = "markets/{0}/{1}";
        internal const string GetPrice = "markets/{0}/{1}/price";
        internal const string GetSummary = "markets/{0}/{1}/summary";
        internal const string GetTrades = "markets/{0}/{1}/trades";
        internal const string GetOrderBook = "markets/{0}/{1}/orderbook";
        internal const string GetOhlc = "markets/{0}/{1}/ohlc";
        internal const string AggregatePrices = "markets/prices";
        internal const string AggregateSummaries = "markets/summaries";
    }
}
