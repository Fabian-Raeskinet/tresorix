using MediatR;
using Tresorix.Domain;

namespace Tresorix.Services;

public interface IDomainEventHandler<in T> : INotificationHandler<T> where T : IDomainEvent
{
    new Task Handle(T domainEvent, CancellationToken cancellationToken);
}