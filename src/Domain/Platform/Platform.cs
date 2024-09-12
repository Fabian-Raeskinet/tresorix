namespace Tresorix.Domain.Platform;

public class Platform(string name) : AggregateRoot<Guid>
{
    public string Name { get; } = name;
    private readonly List<Holding> _holdings = new();
    public IReadOnlyCollection<Holding> Holdings => _holdings.AsReadOnly();

    public void AddAsset(Asset asset)
    {
        var holding = new Holding(asset, this);
        _holdings.Add(holding);
    }
}