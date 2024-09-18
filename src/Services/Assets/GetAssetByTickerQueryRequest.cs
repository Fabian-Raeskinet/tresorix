using Tresorix.Contracts.Assets;

namespace Tresorix.Services.Assets;

public class GetAssetByTickerQueryRequest : GetAssetByTickerQuery, IQuery<AssetResponse>
{
}