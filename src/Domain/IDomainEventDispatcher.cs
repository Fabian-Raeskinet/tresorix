namespace Tresorix.Domain;

public interface IDomainEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent, CancellationToken cancellationToken);
}