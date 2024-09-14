using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tresorix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class AssetController(IMediator mediator) : ControllerBase
{
    public IMediator Mediator { get; set; } = mediator;
}