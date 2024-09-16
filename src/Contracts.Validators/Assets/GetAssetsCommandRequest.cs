using FluentValidation;
using Tresorix.Services.Assets;

namespace Tresorix.Contracts.Validators.Assets;

public class CreateNewAssetCommandRequestValidators : AbstractValidator<CreateNewAssetCommandRequest>
{
    public CreateNewAssetCommandRequestValidators()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Ticker).NotEmpty();
        RuleFor(x => x.ActualValue).GreaterThan(0);
        RuleFor(x => x.AverageYearlyPerformancePercent).GreaterThan(0);
    }
}