using Microsoft.AspNetCore.Mvc;
using Tresorix.Contracts.Assets;
using Tresorix.Services.Assets;

namespace Tresorix.Api.Controllers;

public partial class AssetController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateDisk([FromBody] CreateNewAssetCommand command)
    {
        var request = new CreateNewAssetCommandRequest
        {
            Name = command.Name,
            Ticker = command.Ticker,
            ActualValue = command.ActualValue,
            AverageYearlyPerformancePercent = command.AverageYearlyPerformancePercent,
            PlatformId = command.PlatformId
        };
        await Mediator.Send(request);
        return NoContent();
    }
}