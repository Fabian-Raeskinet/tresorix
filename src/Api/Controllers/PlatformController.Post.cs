using Microsoft.AspNetCore.Mvc;
using Tresorix.Contracts.Platforms;
using Tresorix.Services.Platforms;

namespace Tresorix.Api.Controllers;

public partial class PlatformController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateDisk([FromBody] CreateNewPlatformCommand command)
    {
        var request = new CreateNewPlatformCommandRequest { Name = command.Name, };
        await Mediator.Send(request);
        return NoContent();
    }
}