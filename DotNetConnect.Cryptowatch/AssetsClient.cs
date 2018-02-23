using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetConnect.Cryptowatch.DataModel;

namespace DotNetConnect.Cryptowatch
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
            return await _router.MakeRequest<List<AssetSummary>>(CryptowatchEndpoints.GetAllAssets);
        }

        public async Task<Asset> GetAssetBySymbolAsync(string symbol)
        {
            var formatedRoute = string.Format(CryptowatchEndpoints.GetAsset, symbol);
            return await _router.MakeRequest<Asset>(formatedRoute);
        }
    }
}
