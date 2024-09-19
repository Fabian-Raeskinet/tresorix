using FluentValidation;
using Tresorix.Services.Platforms;

namespace Tresorix.Contracts.Validators.Platforms;

public class CreateNewPlatformCommandRequestValidator : AbstractValidator<CreateNewPlatformCommandRequest>
{
    public CreateNewPlatformCommandRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}