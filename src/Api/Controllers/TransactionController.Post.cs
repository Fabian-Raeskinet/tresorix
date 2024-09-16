using Microsoft.AspNetCore.Mvc;
using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Transactions;
using Tresorix.Services.Assets;
using Tresorix.Services.Transactions;

namespace Tresorix.Api.Controllers;

public partial class TransactionController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateDisk([FromBody] CreateNewTransactionCommand command)
    {
        var request = new CreateNewTransactionCommandRequest
        {
            Date = command.Date,
            Amount = command.Amount,
            Quantity = command.Quantity,
            PriceAtBuy = command.PriceAtBuy,
            Type = command.Type,
            AssetId = command.AssetId,
            PlatformId = command.PlatformId
        };
        await Mediator.Send(request);
        return NoContent();
    }
}