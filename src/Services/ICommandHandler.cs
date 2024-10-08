using MediatR;

namespace Tresorix.Services;

public interface ICommandHandler<in T> : IRequestHandler<T> where T : ICommand
{
    
}