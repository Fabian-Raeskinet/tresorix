namespace Tresorix.Domain;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
}