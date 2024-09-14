using Tresorix.Contracts.Assets;

namespace Tresorix.Services.Assets;

public class GetAssetsQueryRequest : GetAssetsQuery, IQuery<IEnumerable<AssetResponse>>
{
    
}