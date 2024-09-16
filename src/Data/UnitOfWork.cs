using Tresorix.Domain.Platform;
using Tresorix.Services;

namespace Tresorix.Data
{
    public class UnitOfWork(
        ITresorixContext context,
        IPlatformRepository platformRepository,
        IAssetRepository assetRepository)
        : IUnitOfWork
    {
        private readonly ITresorixContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IPlatformRepository _platformRepository = platformRepository ?? throw new ArgumentNullException(nameof(platformRepository));
        private readonly IAssetRepository _assetRepository = assetRepository ?? throw new ArgumentNullException(nameof(assetRepository));

        public IPlatformRepository PlatformRepository => _platformRepository;
        public IAssetRepository AssetRepository => _assetRepository;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}