using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Avanti.WarehouseTwoPrinterService.Order.Api;

public partial class PrivateApiController
{
    [SwaggerResponse(200, "The order is stored")]
    [SwaggerResponse(400, "The order is invalid")]
    [SwaggerOperation(
                Summary = "Upsert a order",
                Description = "Insert or update the given order, identified by id.",
                Tags = new[] { "Order" })]
    [HttpPost]
    public async Task<IActionResult> PostOrder([FromBody] PostOrderRequest request) =>
        await this.printerActorRef.Ask(
            this.mapper.Map<PrinterActor.ExecuteJob>(request)) switch
        {
            PrinterActor.JobCompleted stored => new OkResult(),
            _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
        };
}
