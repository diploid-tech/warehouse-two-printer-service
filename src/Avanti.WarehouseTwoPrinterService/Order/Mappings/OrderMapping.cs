using AutoMapper;
using Avanti.WarehouseTwoPrinterService.Order.Api;

namespace Avanti.WarehouseTwoPrinterService.Order.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<PrivateApiController.PostOrderRequest, PrinterActor.ExecuteJob>();
            CreateMap<PrivateApiController.PostOrderRequest.OrderLine, PrinterActor.ExecuteJob.OrderLine>();
        }
    }
}
