using System.Collections.Generic;
using System.Threading.Tasks;
using HelpfulThings.Connect.Cryptowatch.DataModel;

namespace HelpfulThings.Connect.Cryptowatch
{
    public interface IAssetsClient
    {
        Task<List<AssetSummary>> GetAllAssetsAsync();
        Task<Asset> GetAssetBySymbolAsync(string symbol);
    }

    public class AssetsClient : IAssetsClient
    {
        private readonly IRequestRouter _router;

        public AssetsClient(IRequestRouter router)
        {
            _router = router;
        }

        public async Task<List<AssetSummary>> GetAllAssetsAsync()
        {
            return await _router.MakeRequest<List<AssetSummary>>(CryptowatchEndpoints.AllAssets);
        }

        public async Task<Asset> GetAssetBySymbolAsync(string symbol)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.Asset, symbol);
            return await _router.MakeRequest<Asset>(formatedRoute);
        }
    }
}
