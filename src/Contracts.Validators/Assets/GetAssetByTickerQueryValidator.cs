using FluentValidation;
using Tresorix.Services.Assets;

namespace Tresorix.Contracts.Validators.Assets;

public class GetAssetByTickerQueryValidator : AbstractValidator<GetAssetByTickerQueryRequest>
{
    public GetAssetByTickerQueryValidator()
    {
        RuleFor(x => x.Ticker).NotEmpty();
    }
}