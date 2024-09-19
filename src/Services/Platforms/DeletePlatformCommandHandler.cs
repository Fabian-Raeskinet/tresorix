using Exceptions;

namespace Tresorix.Services.Platforms;

public class DeletePlatformCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeletePlatformCommandRequest>
{
    public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;

    public async Task Handle(DeletePlatformCommandRequest request, CancellationToken cancellationToken)
    {
        var platform = await UnitOfWork.PlatformRepository.GetById(request.Id);
        if (platform is null)
        {
            throw new ObjectNotFoundException("Platform not found.");
        }
        
        UnitOfWork.PlatformRepository.DeleteAsync(platform);
        await UnitOfWork.CommitAsync();
    }
}