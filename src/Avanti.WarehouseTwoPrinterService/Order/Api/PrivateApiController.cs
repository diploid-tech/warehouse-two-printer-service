using AutoMapper;
using Avanti.Core.Microservice.Actors;
using Microsoft.AspNetCore.Mvc;

namespace Avanti.WarehouseTwoPrinterService.Order.Api;

[Route("/private/order")]
[ApiController]
public partial class PrivateApiController
{
    private readonly IMapper mapper;
    private readonly IActorRef printerActorRef;
    private readonly ILogger logger;

    public PrivateApiController(
        IActorProvider<PrinterActor> printerActorProvider,
        ILogger<PrivateApiController> logger,
        IMapper mapper)
    {
        this.printerActorRef = printerActorProvider.Get();
        this.logger = logger;
        this.mapper = mapper;
    }
}
