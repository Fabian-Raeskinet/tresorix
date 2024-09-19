using FluentValidation;
using Tresorix.Services.Platforms;

namespace Tresorix.Contracts.Validators.Platforms;

public class GetPlatformByNameQueryRequestValidator : AbstractValidator<GetPlatformByNameQueryRequest>
{
    public GetPlatformByNameQueryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}