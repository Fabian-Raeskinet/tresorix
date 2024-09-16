using FluentValidation;
using Tresorix.Services.Transactions;

namespace Tresorix.Contracts.Validators.Transactions;

public class CreateNewTransactionCommandValidators : AbstractValidator<CreateNewTransactionCommandRequest>
{
    public CreateNewTransactionCommandValidators()
    {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        RuleFor(x => x.PriceAtBuy).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.AssetId).NotEmpty();
        RuleFor(x => x.PlatformId).NotEmpty();
    }
}