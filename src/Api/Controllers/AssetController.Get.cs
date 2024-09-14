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
        var query = new GetAssetsQueryRequest();
        var results = await Mediator.Send(query);
        return Ok(results);
    }
}