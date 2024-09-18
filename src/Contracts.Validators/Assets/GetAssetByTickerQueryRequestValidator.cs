using FluentValidation;
using Tresorix.Services.Assets;

namespace Tresorix.Contracts.Validators.Assets;

public class GetAssetByTickerQueryRequestValidator : AbstractValidator<GetAssetByTickerQueryRequest>
{
    public GetAssetByTickerQueryRequestValidator()
    {
        RuleFor(x => x.Ticker).NotEmpty();
    }
}