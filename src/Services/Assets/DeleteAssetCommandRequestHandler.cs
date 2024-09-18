using Exceptions;

namespace Tresorix.Services.Assets;

public class DeleteAssetCommandRequestHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteAssetCommandRequest>
{
    private IUnitOfWork UnitOfWork { get; set; } = unitOfWork;

    public async Task Handle(DeleteAssetCommandRequest request, CancellationToken cancellationToken)
    {
        var asset = await UnitOfWork.AssetRepository.GetById(request.Id);

        if (asset is null)
            throw new ObjectNotFoundException("no asset found");

        UnitOfWork.AssetRepository.Delete(asset);
        await UnitOfWork.CommitAsync();
    }
}