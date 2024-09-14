using MediatR;

namespace Tresorix.Services;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
    
}