namespace HelpfulThings.Connect.Cryptowatch
{
    internal static class CryptowatchEndpoints
    {
        internal const string CheckBalance = "/";
        internal const string AllAssets = "assets";
        internal const string Asset = "assets/{0}";
        internal const string AllPairs = "pairs";
        internal const string Pair = "pairs/{0}";
        internal const string AllExchanges = "exchanges";
        internal const string Exchange = "exchanges/{0}";
        internal const string AllMarkets = "markets";
        internal const string MarketDetail = "markets/{0}/{1}";
        internal const string Price = "markets/{0}/{1}/price";
        internal const string Summary = "markets/{0}/{1}/summary";
        internal const string Trades = "markets/{0}/{1}/trades";
        internal const string OrderBook = "markets/{0}/{1}/orderbook";
        internal const string Ohlc = "markets/{0}/{1}/ohlc";
        internal const string AggregatePrices = "markets/prices";
        internal const string AggregateSummaries = "markets/summaries";
    }
}
