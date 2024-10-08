using MassTransit;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Tresorix.Data.Configurations;

public class NewIdGenerator : ValueGenerator<Guid>
{
    #region Base Class Member Overrides

    public override Guid Next(EntityEntry entry)
    {
        return NewId.NextGuid();
    }

    public override bool GeneratesTemporaryValues { get; }

    #endregion
}