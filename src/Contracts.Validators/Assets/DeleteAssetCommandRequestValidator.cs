using FluentValidation;
using Tresorix.Services.Assets;

namespace Tresorix.Contracts.Validators.Assets;

public class DeleteAssetCommandRequestValidator : AbstractValidator<DeleteAssetCommandRequest>
{
    public DeleteAssetCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}