using Tresorix.Domain.Platform;

namespace Tresorix.Services.Transactions;

public class CreateNewTransactionCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateNewTransactionCommandRequest>
{
    public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;

    public async Task Handle(CreateNewTransactionCommandRequest request, CancellationToken cancellationToken)
    {
        var asset = await UnitOfWork.AssetRepository.GetById(request.AssetId);
        var platform = await UnitOfWork.PlatformRepository.GetById(request.PlatformId);

        var transaction = new Transaction(request.Date, request.Amount, (TransactionType)request.Type, asset,
            request.PriceAtBuy);

        platform.AddTransaction(transaction);

        await UnitOfWork.CommitAsync();
    }
}