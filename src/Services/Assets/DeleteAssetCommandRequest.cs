namespace Tresorix.Services.Assets;

public class DeleteAssetCommandRequest : ICommand
{
    public Guid Id { get; set; }
}