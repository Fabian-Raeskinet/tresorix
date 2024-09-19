using Tresorix.Domain.Platform;

namespace Tresorix.Services.Platforms;

public class CreateNewPlatformCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateNewPlatformCommandRequest>
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task Handle(CreateNewPlatformCommandRequest request, CancellationToken cancellationToken)
    {
        var platform = new Platform(request.Name);

        await UnitOfWork.PlatformRepository.CreateAsync(platform);
        await UnitOfWork.CommitAsync();
    }
}