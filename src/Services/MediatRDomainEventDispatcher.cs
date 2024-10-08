using MediatR;
using Tresorix.Domain;

namespace Tresorix.Services;

public class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    public IMediator Mediator { get; }

    public MediatRDomainEventDispatcher(IMediator mediator)
    {
        Mediator = mediator;
    }

    public async Task Dispatch(IDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        await Mediator.Publish(domainEvent, cancellationToken);
    }
}