using Microsoft.AspNetCore.Mvc;
using Tresorix.Contracts.Platforms;
using Tresorix.Services.Platforms;

namespace Tresorix.Api.Controllers;

public partial class PlatformController
{
    [HttpGet("{platformId}")]
    [ProducesResponseType(typeof(IEnumerable<PlatformPredictionResponse>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetPredictions([FromRoute] Guid platformId, [FromQuery] GetPlatformPredictionQuery query)
    {
        var request = new GetPlatformPredictionQueryRequest { Years = query.Years, PlatformId = platformId };
        var results = await Mediator.Send(request);
        return Ok(results);
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PlatformResponse>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetPlatformsQueryRequest();
        var results = await Mediator.Send(request);
        return Ok(results);
    }
}