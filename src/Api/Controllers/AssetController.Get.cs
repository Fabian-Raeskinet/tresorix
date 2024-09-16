using Microsoft.AspNetCore.Mvc;
using Tresorix.Contracts.Assets;
using Tresorix.Services.Assets;

namespace Tresorix.Api.Controllers;

public partial class AssetController
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AssetResponse>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllDisks()
    {
        var request = new GetAssetsQueryRequest();
        var results = await Mediator.Send(request);
        return Ok(results);
    }
}