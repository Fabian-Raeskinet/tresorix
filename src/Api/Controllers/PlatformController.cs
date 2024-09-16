using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tresorix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class PlatformController(IMediator mediator) : ControllerBase
{
    private IMediator Mediator { get; } = mediator;
}