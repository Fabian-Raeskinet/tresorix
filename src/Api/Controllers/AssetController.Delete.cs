using Microsoft.AspNetCore.Mvc;
using Tresorix.Services.Assets;

namespace Tresorix.Api.Controllers;

public partial class AssetController
{
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetPredictions([FromRoute] Guid id)
    {
        var request = new DeleteAssetCommandRequest() { Id = id };
        await Mediator.Send(request);
        return NoContent();
    }
}