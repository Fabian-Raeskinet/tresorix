using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public interface ITresorixContext
{
    DbSet<Platform> Platforms { get; }
    DbSet<Asset> Assets { get; }
    DbSet<Transaction> Transactions { get; }
    Task<int> SaveChangesAsync();
}