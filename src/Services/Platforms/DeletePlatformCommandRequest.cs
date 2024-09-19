namespace Tresorix.Services.Platforms;

public class DeletePlatformCommandRequest : ICommand
{
    public Guid Id { get; set; }
}