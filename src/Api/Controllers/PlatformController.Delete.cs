using Microsoft.AspNetCore.Mvc;
using Tresorix.Contracts.Validators.Platforms;
using Tresorix.Services.Assets;
using Tresorix.Services.Platforms;

namespace Tresorix.Api.Controllers;

public partial class PlatformController
{
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeletePlatform([FromRoute] Guid id)
    {
        var request = new DeletePlatformCommandRequest { Id = id };
        await Mediator.Send(request);
        return NoContent();
    }
}