using System.Collections.Generic;
using System.Threading.Tasks;
using HelpfulThings.Connect.Cryptowatch.DataModel;

namespace HelpfulThings.Connect.Cryptowatch
{
    public interface IPairsClient
    {
        Task<List<PairSummary>> GetAllPairsAsync();
        Task<Pair> GetPairBySymbolAsync(string symbol);
    }

    public class PairsClient : IPairsClient
    {
        private readonly IRequestRouter _router;

        public PairsClient(IRequestRouter router)
        {
            _router = router;
        }

        public async Task<List<PairSummary>> GetAllPairsAsync()
        {
            return await _router.MakeRequest<List<PairSummary>>(CryptowatchEndpoints.AllPairs);
        }

        public async Task<Pair> GetPairBySymbolAsync(string symbol)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.Pair, symbol);
            return await _router.MakeRequest<Pair>(formatedRoute);
        }
    }
}
